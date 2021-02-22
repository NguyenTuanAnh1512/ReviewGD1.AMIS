<template>
  <button 
    class="button"
    :class="{button_with_icon: haveIcon}"
    :style="'background-image:url('+ urlBackground +');'"
    @click="btnAddOnClick"
    >{{ btnText }}</button>
</template>

<script>
export default {
  name: "BaseButton",
  data() {
    return {
      
    }
  },
  props: {
    btnText: String,
    urlBackground: String,
    haveIcon: Boolean,
  },
  methods: {
    btnAddOnClick() {
      // console.log("ham trong button");
      this.$emit("btnOnClick")
    },
  },
}
</script>

<style scoped>
  .button {
    height: 40px;
    background-color: #019160;
    border-radius: 4px;
    font-size: 13px;
    color: #ffffff;
    padding-left: 24px;
    padding-right: 24px;
    text-align: center;
    border: none;
    outline: none !important;
    cursor: pointer;
    /* min-width: 100px; */
  }

  .button:hover {
    background-color: #2FBE8E;
  }

  .button:active {
    background-color: #01B075;
  }
  
  .button_with_icon {
    background-repeat: no-repeat;
    background-size: 16px;
    background-position: 16px 11px;
    padding-left: calc(16px + 16px + 8px);
  }
</style>