<template>
  <div class="loader" v-if="loading">
    <span class="helper"></span>
    <img class="loaderImg" src="../assets/ajax-loader.gif">
  </div>
</template>

<script>

export default  {
    name: 'v-spinner',
    props: { loading: Boolean},
  methods: {
    
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

.loader {
  /* Loader Div Class */
  position: absolute;
  top: 0px;
  right: 0px;
  width: 100%;
  height: 100%;
  background-color: #eceaea;
  background-image: url("~@/assets/ajax-loader.gif");
  background-size: 50px;
  background-repeat: no-repeat;
  background-position: center;
  z-index: 10000000;
  opacity: 0.4;
  filter: alpha(opacity=40);
}

.helper {
  display: inline-block;
  height: 100%;
  vertical-align: middle;
}

.loaderImg {
  vertical-align: middle;
  max-height: 100px;
  max-width: 160px;
}

</style>  