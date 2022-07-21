<template>
  <div id="search" class="container">
    <div class="card">
      <div class="card-body">
        <h4 class="card-title">{{ test.name }}</h4>
        <h6>{{ test.hex }}</h6>
        <!-- <h6 class="card-title">{{ test.category }}</h6> -->
        <p class="card-text">
          {{ test.description }}
        </p>
      </div>
      <div
        style="height: 200px; width: 100%"
        :style="{ background: test.hex }"
      ></div>
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
      test: 'Test',
    };
  },
  mounted() {
    colourHelper.getNearestColour(22, 44, 66).then(
      (x) => {
        this.test = x[0];
      },
      (e) => {
        this.test = e?.message;
      }
    );
  },
};
</script>

<style scoped></style>
