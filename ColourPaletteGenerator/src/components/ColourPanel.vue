<template>
  <div class="hello">
    
    <div v-if="colours">
      <div v-for="(color, index) in Object.values(this.colours.colours)" :key="index" :style="{ backgroundColor: color }" class="colour-container"></div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    msg: String,
    colours: Object
  }
}
</script>

<style scoped>
.hello {
  text-align: center;
}

.colour-container {
  display: inline-block;
  margin: 10px;
  width: 100px;
  height: 100px;
}
</style>