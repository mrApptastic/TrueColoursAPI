<template>
  <div class="container-fluid">
  <MainNav />
    <div class="container">
      <h1>True Colours API Demo App</h1>
    <p>
      This application includes 3 demos of usage of the True Colours API. 
    </p>
        <a href="https://colours.tesj.dk/" target="_blank" class="btn btn-primary">See Swagger Documentation</a>
  </div>
  <hr/>
  <UploadView />
  <SliderView />
  <ColorWheelView />
</template>

<script>
import MainNav from './MainNav.vue';
import UploadView from './UploadView.vue';
import SliderView from './SliderView.vue';
import ColorWheelView from './ColorWheelView.vue';

export default {
  name: 'HelloWorld',
  components: {
    MainNav,
    UploadView,
    SliderView,
    ColorWheelView
  }
};
</script>

<style scoped></style>
