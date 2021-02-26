<template>
  <div id="radio">
    <label 
      class="container"
      v-for="(data, index) in datas" :key="index"  
    > {{ data.label }}
      <input 
        type="radio" name="radio"
        :value="data.value"
        v-model="choosed"
        @click="changeRadio(data.value)"
      >
      <span class="checkmark"></span>
    </label>
  </div>
</template>

<script>
export default {
name: 'BaseRadio',
props: {
  datas: Array,
  choosed: Number,
},
data() {
  return {
    
  }
},

methods: {
  changeRadio(val) {
    this.$emit('changeRadio', val);
  }
},
}

</script>

<style scoped>

.container {
  display: inline-block;
  position: relative;
  padding-left: 25px;
  margin-bottom: 12px;
  margin-right: 20px;
  cursor: pointer;
  font-size: 13px;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
}

/* Hide the browser's default radio button */
.container input {
  position: absolute;
  opacity: 0;
  cursor: pointer;
  margin-left: 20px;
}

/* Create a custom radio button */
.checkmark {
  position: absolute;
  top: 0;
  left: 0;
  height: 20px;
  width: 20px;
  background-color: #eee;
  border-radius: 50%;
  /* background: url('../../assets/img/radio-checked.png'); */
}

/* On mouse-over, add a grey background color */
.container:hover input ~ .checkmark {
  background-color: #ccc;
}

/* When the radio button is checked, add a blue background */
.container input:checked ~ .checkmark {
  background: url('../../assets/img/radio-checked.png');
}

/* Create the indicator (the dot/circle - hidden when not checked) */
.checkmark:after {
  content: "";
  position: absolute;
  display: none;
}

/* Show the indicator (dot/circle) when checked */
.container input:checked ~ .checkmark:after {
  display: block; 
}

/* Style the indicator (dot/circle) */
/* .container .checkmark:after {
  top: 9px;
	left: 9px;
	width: 12px;
	height: 12px;
	border-radius: 50%;
	background: white;
} */
</style>