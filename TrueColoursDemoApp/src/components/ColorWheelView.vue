<template>
  <div id="wheel" class="container">
    <h2>Demo Three: List of closest colours from the Colour Wheel</h2>
    <p>
      No user action for this one. Just a list of the 12 nearest colours
      matching the 6 base colours from the <em>Color Wheel</em>.
    </p>
    <div class="row" v-if="red">
      <h3>Red</h3>
      <div
        class="col-md-4 col-lg-3"
        v-for="item in red"
        v-bind:key="item.publicId"
      >
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
    <div class="row" v-if="orange">
      <h3>Orange</h3>
      <div
        class="col-md-4 col-lg-3"
        v-for="item in orange"
        v-bind:key="item.publicId"
      >
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
    <div class="row" v-if="yellow">
      <h3>Yellow</h3>
      <div
        class="col-md-4 col-lg-3"
        v-for="item in yellow"
        v-bind:key="item.publicId"
      >
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
    <div class="row" v-if="green">
      <h3>Green</h3>
      <div
        class="col-md-4 col-lg-3"
        v-for="item in green"
        v-bind:key="item.publicId"
      >
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
    <div class="row" v-if="blue">
      <h3>Blue</h3>
      <div
        class="col-md-4 col-lg-3"
        v-for="item in blue"
        v-bind:key="item.publicId"
      >
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
    <div class="row" v-if="violet">
      <h3>Violet</h3>
      <div
        class="col-md-4 col-lg-3"
        v-for="item in violet"
        v-bind:key="item.publicId"
      >
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
</template>

<script>
import * as colourHelper from '../functions/colourHelper.js';

export default {
  data: function () {
    return {
      red: null,
      orange: null,
      yellow: null,
      green: null,
      blue: null,
      violet: null,
    };
  },
  mounted() {
    colourHelper.getNearestColour(248, 0, 0).then(
      (x) => {
        this.red = x;
      },
      (e) => {
        console.log(e?.message);
      }
    );

    colourHelper.getNearestColour(255, 165, 0).then(
      (x) => {
        this.orange = x;
      },
      (e) => {
        console.log(e?.message);
      }
    );

    colourHelper.getNearestColour(255, 255, 0).then(
      (x) => {
        this.yellow = x;
      },
      (e) => {
        console.log(e?.message);
      }
    );

    colourHelper.getNearestColour(0, 128, 0).then(
      (x) => {
        this.green = x;
      },
      (e) => {
        console.log(e?.message);
      }
    );

    colourHelper.getNearestColour(0, 0, 255).then(
      (x) => {
        this.blue = x;
      },
      (e) => {
        console.log(e?.message);
      }
    );

    colourHelper.getNearestColour(238, 130, 238).then(
      (x) => {
        this.violet = x;
      },
      (e) => {
        console.log(e?.message);
      }
    );
  },
};
</script>

<style scoped>
div#wheel {
  padding-top: 50px;
  min-height: 100vh;
}
</style>
