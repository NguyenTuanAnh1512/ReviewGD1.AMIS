<template>
  <div id="app">
    <TheNavbar />
    <TheHeader />
    <TheContent />
  </div>
</template>

<script>
import TheNavbar from './components/layout/TheNavbar'
import TheHeader from './components/layout/TheHeader'
import TheContent from './components/layout/TheContent'


export default {
  name: 'App',
  props: {

  },
  components: {
    TheNavbar,
    TheHeader,
    TheContent,
  },
  methods: {
    
  },
  data() {
    return {
      
    }
  },
  computed: {

  },
}
</script>

<style>
@font-face {
    font-family: Notosans-Regular;
    src: url('./assets/fonts/notosans-regular.2cb88a13.woff2');
}

@font-face {
    font-family: Notosans-Bold;
    src: url('./assets/fonts/notosans-bold.3ede5aff.woff2');
}

@font-face {
    font-family: Notosans-Italic;
    src: url('./assets/fonts/notosans-italic.1c1aaac9.woff2');
}

@font-face {
    font-family: Notosans-Semibold;
    src: url('./assets/fonts/notosans-semibold.df3e6dc4.woff2');
}

#app {
  font-family: Notosans-Regular;
  font-size: 13px;
  box-sizing: border-box;
}

body {
  margin: 0;
}


/* Input */
.input {
  border: 1px solid #bbbbbb;
  border-radius: 3px;
  height: 30px;
  box-sizing: border-box;
  font-size: 12px;
  font-size: 13px;
  margin-top: 4px;
  padding-left: 14px;
  padding-right: 14px;
}

.input:focus {
  outline: none !important;
  border: 1px solid #019160;
}

.input_fail::-webkit-input-placeholder {
  font-size: 12px;
  color: red !important;
}

.input::-webkit-input-placeholder {
  font-size: 12px;
  color: #bbbbbb;
}

.input-label {
  font-size: 13px;
  color: #000000;
}

.input-with-icon {
  border: 1px solid #bbbbbb;
  border-radius: 3px;
  height: 30px;
  box-sizing: border-box;
  font-size: 12px;
  font-size: 13px;
  /* background-image: url('./assets/content/icon/search.png'); */
  background-repeat: no-repeat;
  background-size: 16px;
  background-position: 10px 10px;
  padding-left: 14px;
  padding-right: 30px;
}
</style>
