<template>
  <div id="slider" class="container">
    {{ test }}
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
        this.test = x[0].hex;
      },
      (e) => {
        this.test = e?.message;
      }
    );
  },
};
</script>

<style scoped></style>
