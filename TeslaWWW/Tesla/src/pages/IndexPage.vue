<template>
  <q-page class="row items-center justify-evenly">
    <q-select class="full-width" :options="localisationOptions" v-model="reservation.localisationId" map-options emit-value dense label="Localisation" option-value="id" option-label="name"></q-select>
    <q-radio v-model="reservation.carId" v-for="car in carOptions" :key="car.id" :val="car.id" :label="car.name + ' - ' + car.costPerDay + ' $'"></q-radio>
    <q-input v-model="reservation.phone" dense mask="###-###-###" label="Phone number"></q-input>
    <q-input v-model="reservation.firstName" dense label="Firstname"></q-input>
    <q-input v-model="reservation.lastName" dense label="Lastname"></q-input>
    <q-input v-model="reservation.email" dense label="Email" :rules="[(val, rules) => rules.email(val) || 'Please enter a valid email address']"></q-input>
    <q-date v-model="dateRange" range/>
    <h5 v-show="totalCost">Total Cost: {{ totalCost }} $</h5>
    <q-btn label="Reserve now!" @click="reservate" :disable="!totalCost"/>
  </q-page>
</template>

<script lang="ts">
import { useQuasar } from 'quasar';
import { api } from 'src/boot/axios';
import { defineComponent, reactive } from 'vue';

export default defineComponent({
  name: 'IndexPage',
  data() {
    return{
      localisationOptions: [],
      carOptions: [],
      reservation: reactive({
        firstName: null,
        lastName: null,
        email: null,
        phone: null,
        carId: null,
        localisationId: null,
        dateFrom: '',
        dateTo: ''
      }),
      returnReservationId: null,
      dateRange: reactive({
        from: '2023-03-27',
        to: '2023-03-31'
      }),
      totalCost: null,
      q: useQuasar()
    }
  },
  methods: {
    getCars() {
      api.get('/cars')
      .then((response) => {
        this.carOptions = response.data
      })
      .catch(() => {
        this.q.notify({
          message: 'No cars to show.',
          type: 'negative'
        })
      })
    },
    getLocalisation() {
      api.get('/localisations')
      .then((response) => {
        this.localisationOptions = response.data
      })
      .catch(() => {
        this.q.notify({
          message: 'No localisation to show.',
          type: 'negative'
        })
      })
    },
    getTotalCost() {
      api.get('/reservations/get-total-cost', {params: {carId: this.reservation.carId, dateFrom: this.dateRange.from, dateTo: this.dateRange.to}})
      .then((response) => {
        this.totalCost = response.data
      })
      .catch(() => {
        this.q.notify({
          message: 'Calculate error.',
          type: 'negative'
        })
      })
    },
    createReservation() {
      if(this.reservation.firstName && this.reservation.lastName && this.reservation.email && this.reservation.phone && this.reservation.dateFrom && this.reservation.dateTo && this.reservation.carId && this.reservation.localisationId) {
      api.post('/reservations', {FirstName: this.reservation.firstName,
        lastName: null,
        email: null,
        phone: null,
        carId: null,
        localisationId: null,
        dateFrom: '',
        dateTo: ''})
      .then(() => {
        this.q.notify({
          message: 'Reservation created.',
          type: 'positive'
        })
      })
      .catch(() => {
        this.q.notify({
          message: 'Create reservation error.',
          type: 'negative'
        })
      })
    }
    else {
      this.q.notify({
          message: 'Inputs can\'t be emptry!',
          type: 'negative'
        })
    }
  },
    returnCar() {
      api.post(`/reservations/${this.returnReservationId}/return`)
      .then(() => {
        this.q.notify({
          message: 'Car returned.',
          type: 'positive'
        })
      })
      .catch(() => {
        this.q.notify({
          message: 'Car return error.',
          type: 'negative'
        })
      })
    },
    reservate() {
      this.reservation.dateFrom=this.dateRange.from,
      this.reservation.dateTo=this.dateRange.to,
      this.createReservation()
    }
  },
  watch: {
    dateRange(newDateRange, oldDateRange) {
      if(this.reservation.carId && this.dateRange.from && this.dateRange.to){
        this.getTotalCost()
      }
    },
    reservation(newDateRange, oldDateRange) {
      if(this.reservation.carId && this.dateRange.from && this.dateRange.to){
        this.getTotalCost()
      }
    }
  },
  beforeMount() {
    this.getCars()
    this.getLocalisation()
  }
});
</script>
