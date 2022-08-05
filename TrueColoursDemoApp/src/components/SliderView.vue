<template>
  <div id="slider" class="container">
      <h2>Demo Two: Get Nearest Colours From RGB Values</h2>
    <p>
      In this demo you can change the sliders and the API will fetch and show the closest 12 colours.
    </p>
    Red {{ red }}
    <input
      type="range"
      min="0"
      max="255"
      v-model="red"
      v-on:change="checkColour()"
    /><br />
    Green {{ green }}
    <input
      type="range"
      min="0"
      max="255"
      v-model="green"
      v-on:change="checkColour()"
    /><br />
    Blue {{ blue }}
    <input
      type="range"
      min="0"
      max="255"
      v-model="blue"
      v-on:change="checkColour()"
    /><br />
    <div class="row" v-if="test">
      <div class="col-md-4 col-lg-3" v-for="item in test" v-bind:key="item.publicId">
        <div class="card">
            <div class="card-body">
              <h4 class="card-title">{{ item.name }}</h4>
              <h6>{{ item.hex }}</h6>
              <p class="card-text">
                {{ item.description }}
              </p>
            </div>
            <div
              style="height: 200px; width: 100%"
              :style="{ background: item.hex }"
            ></div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import * as colourHelper from '../functions/colourHelper.js';

export default {
  props: {
    msg: String,
  },
  data: function () {
    return {
      red: 122,
      green: 122,
      blue: 122,
      test: null,
    };
  },
  methods: {
    checkColour: function () {
      colourHelper.getNearestColour(this.red, this.green, this.blue).then(
        (x) => {
          this.test = x;
        },
        (e) => {
          this.test = e?.message;
        }
      );
    },
  },
};
</script>

<style scoped>
div#slider {
  padding-top: 50px;
  min-height: 100vh;
}
</style>
