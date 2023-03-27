<template>
  <q-page class="fit column wrap justify-center content-center bg-white shadow-24" style="max-width: 600px; margin: auto;">
      <div class="row q-pa-md">
        <div class="full-width row q-pa-md">
          <q-select class="full-width" :options="localisationOptions" v-model="reservation.localisationId" map-options emit-value dense label="Localisation" option-value="id" option-label="name"></q-select>
        </div>
        <div class="row q-pa-md full-width justify-evenly">
          <q-radio v-model="reservation.carId" v-for="car in carOptions" :key="car.id" :val="car.id" :label="car.name + ' - ' + car.costPerDay + ' $'"></q-radio></div>
        </div>
    <div class="row q-pa-md">
      <div class="row q-pa-md full-width">
        <q-input class="full-width" v-model="reservation.phone" dense mask="###-###-###" label="Phone number"></q-input>
      </div>
      <div class="full-width row q-pa-md">
        <q-input class="full-width" v-model="reservation.firstName" dense label="Firstname"></q-input>
      </div>
      <div class="full-width row q-pa-md">
        <q-input class="full-width" v-model="reservation.lastName" dense label="Lastname"></q-input>
      </div>
      <div class="full-width row q-pa-md">
        <q-input class="full-width" v-model="reservation.email" dense label="Email" :rules="[(val, rules) => rules.email(val) || 'Please enter a valid email address']"></q-input>
      </div>
    </div>
    <div class="full-width justify-center row q-pa-md">
      <q-date v-model="dateRange" range/>
    </div>
    <div class="full-width justify-center row q-pa-md">
      <h5 v-show="totalCost">Total Cost: {{ totalCost }} $</h5>
      <q-btn class="full-width" color="primary" label="Reserve now!" @click="reservate" :disable="!totalCost"/>
    </div>
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
      reservation: {
        firstName: null,
        lastName: null,
        email: null,
        phone: null,
        carId: null,
        localisationId: null,
        dateFrom: '',
        dateTo: ''
      },
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
      console.log(this.reservation)
      if(this.reservation.firstName && this.reservation.lastName && this.reservation.email && this.reservation.phone && this.reservation.dateFrom && this.reservation.dateTo && this.reservation.carId && this.reservation.localisationId) {
      api.post('/reservations', {firstName: this.reservation.firstName,
        lastName: this.reservation.lastName,
        email: this.reservation.email,
        phone: this.reservation.phone,
        carId: this.reservation.carId,
        localisationId: this.reservation.localisationId,
        dateFrom: new Date(this.reservation.dateFrom),
        dateTo: new Date(this.reservation.dateTo)
      })
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
