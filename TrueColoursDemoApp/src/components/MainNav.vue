<template>
  <div class="container-fluid">
    <ul class="nav nav-tabs">
      <li class="nav-item">
        <a class="nav-link" href="#upload">From Upload</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#slider">From Sliders</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#wheel">From Colour Wheel</a>
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  name: 'HelloWorld',
  props: {
    msg: String,
  },
};
</script>

<style scoped>
div.container-fluid {
  top: 0;
  position: sticky;
  background: white;
  z-index: 1;
}
</style>
