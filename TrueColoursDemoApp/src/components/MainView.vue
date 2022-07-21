<template>
  <div class="container-fluid">
  <MainNav />
  <UploadView />
  <SearchView />
  <SliderView />
</template>

<script>
import MainNav from './MainNav.vue';
import UploadView from './UploadView.vue';
import SearchView from './SearchView.vue';
import SliderView from './SliderView.vue';

export default {
  name: 'HelloWorld',
  components: {
    MainNav,
    UploadView,
    SearchView,
    SliderView
  },
  props: {
    msg: String,
  },
};
</script>

<style scoped></style>
