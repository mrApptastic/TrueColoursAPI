<template>
  <div id="upload" class="container">
    <h3>Step One: Upload an image</h3>
    <canvas
      id="uploadCanvas"
      v-on:click="(event) => checkColour(event)"
    ></canvas>
    <button class="btn btn-primary" v-on:click="upload()">Upload Image</button>
    <input id="fileBandit" type="file" v-on:change="changeImage()" />
  </div>
</template>

<script>
import * as colourHelper from '../functions/colourHelper.js';

let ctx;
setTimeout(() => {
  ctx = document.getElementById('uploadCanvas').getContext('2d');
});

export default {
  props: {
    msg: String,
  },
  data: function () {
    return {
      test: 'Test',
    };
  },
  methods: {
    upload: function () {
      document.getElementById('fileBandit').click();
    },
    changeImage: function () {
      const input = document.getElementById('fileBandit');
      const huhu = new Image();
      if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
          huhu.src = e.target.result;
          setTimeout(ctx.drawImage(huhu, 0, 0, 400, 400), 400);
        };
        reader.readAsDataURL(input.files[0]);
      }
    },
    checkColour: function (evt) {
      const area = document.getElementById('uploadCanvas');
      const x =
        evt.pageX - (area.getBoundingClientRect().left + window.scrollX);
      const y = evt.pageY - (area.getBoundingClientRect().top + window.scrollY);
      const i = document
        .getElementById('uploadCanvas')
        .getContext('2d')
        .getImageData(x, y, 1, 1);
      const r = i.data[0];
      const g = i.data[1];
      const b = i.data[2];
      alert(r + '-' + g + '-' + b);
    },
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

<style scoped>
div#upload {
  min-height: 100vh;
}

canvas#uploadCanvas {
  background: snow;
}

input#fileBandit {
  display: none;
}
</style>
