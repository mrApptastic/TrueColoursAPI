<template>
  <div id="upload" class="container">
    <h2>Demo One: Get Colour From Uploaded Image</h2>
    <p>
      In this demo you can upload an image into an HTML Canvas element, and
      request the nearest colour name for a specific pixel you click on.
    </p>
    <h3 v-if="!imageLoaded">Step One: Upload an image</h3>
    <div class="canvasFrame">
      <canvas
        id="uploadCanvas"
        v-on:click="(event) => checkColour(event)"
      ></canvas>
    </div>
    <button class="btn btn-primary" v-on:click="upload()">Upload Image</button>

    <h3 v-if="!test">
      Step Two: Click on the canvas and a request will be fired for RGB value of
      this pixel.
    </h3>
    <input id="fileBandit" type="file" v-on:change="changeImage()" />
    <div v-if="test">
      <div class="card">
        <div class="card-body">
          <h4 class="card-title">{{ test.name }}</h4>
          <h6>{{ test.hex }}</h6>
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
      test: null,
      imageLoaded: false,
    };
  },
  methods: {
    upload: function () {
      document.getElementById('fileBandit').click();
    },
    changeImage: function () {
      const input = document.getElementById('fileBandit');
      const area = document.getElementById('uploadCanvas');
      const huhu = new Image();
      if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
          huhu.src = e.target.result;
          ctx.clearRect(0, 0, area.width, area.height);
          ctx.font = '30px Arial';
          ctx.fillStyle = '#FFFFFF';
          ctx.fillText('Loading Image...', 30, 50);
          setTimeout(() => {
            area.width = huhu.width;
            area.height = huhu.height;
            ctx.clearRect(0, 0, area.width, area.height);
            ctx.drawImage(huhu, 0, 0, huhu.width, huhu.height);
          }, 1000);
        };
        reader.readAsDataURL(input.files[0]);
        this.imageLoaded = true;
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
      colourHelper.getNearestColour(r, g, b).then(
        (x) => {
          this.test = x[0];
        },
        (e) => {
          this.test = e?.message;
        }
      );
    },
  },
  mounted() {
    // colourHelper.getNearestColour(22, 44, 66).then(
    //   (x) => {
    //     this.test = x[0].hex;
    //   },
    //   (e) => {
    //     this.test = e?.message;
    //   }
    // );
  },
};
</script>

<style scoped>
div#upload {
  padding-top: 50px;
  min-height: 100vh;
}

div.canvasFrame {
  width: 100%;
  max-height: 400px;
  overflow: auto;
}

button.btn-primary {
  margin-top: 10px;
  margin-bottom: 10px;
}

canvas#uploadCanvas {
  background: black;
  cursor: pointer;
}

input#fileBandit {
  display: none;
}
</style>
