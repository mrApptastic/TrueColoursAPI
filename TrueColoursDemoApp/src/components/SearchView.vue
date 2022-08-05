<template>
  <div id="search" class="container">
    <h2>Demo 1: Search Colours By Names</h2>
    <p>
      Just type in the search text in the text box below, press the search
      button and the magic will happen...
    </p>
    <div class="row">
      <div class="col-md-9">
        <br />
        <input
          type="text"
          class="form-control"
          placeholder="Search Colours"
          v-model="searchText"
        />
      </div>
      <div class="col-md-3">
        <br />
        <button class="btn btn-success" v-on:click="searchColours()">
          Search
        </button>
      </div>
    </div>
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

    <!-- <div class="card">
      <div class="card-body">
        <h4 class="card-title">{{ test.name }}</h4>
        <h6>{{ test.hex }}</h6>
        <h6 class="card-title">{{ test.category }}</h6>
        <p class="card-text">
          {{ test.description }}
        </p>
      </div>
      <div
        style="height: 200px; width: 100%"
        :style="{ background: test.hex }"
      ></div>
    </div> -->
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
      searchText: '',
      test: null,
    };
  },
  methods: {
    searchColours: function () {
      colourHelper.searchColours(this.searchText, 1, 12, null).then(
        (x) => {
          this.test = x;
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
    //     this.test = x[0];
    //   },
    //   (e) => {
    //     this.test = e?.message;
    //   }
    // );
  },
};
</script>

<style scoped>
div#search {
  min-height: 100vh;
}

button.btn-success {
  width: 100%;
}
</style>
