<template>
  <div :class="{ isHide: isHideBasePopup }">
    <div id="popup-model"></div>
    <div id="popup">
      <div class="popup-msg">
        <div class="popup-msg-icon"></div>
        <div class="popup-msg-text">{{ msg }}</div>
      </div>
      <div class="popup-confirm">
        <BaseButton
          @btnOnClick="btnOkOnClick"
          id="btnOk"
          btnText = "OK"
        />
      </div>
    </div>
  </div>
</template>

<script>
import BaseButton from './BaseButton'

export default {
  name: 'BasePopup',
  props: {
    isHideBasePopup: Boolean,
  },
  components: {
    BaseButton,
  },
  data() {
    return {
      msg: '',
    }
  },
  methods: {
    // khi ấn No, không làm gì và đóng Popup
    // CreatedBy: NTANH (22/01/2021)
    btnOkOnClick() {
      this.$parent.closeBasePopup();
    },
  },
}
</script>

<style scoped>
#popup-model {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  background-color: black;
  opacity: 0.4;
  z-index: 99;
}

#popup {
  --witdhPopup: 400px;
  --heighPopup: 200px;
  width: var(--witdhPopup);
  height: var(--heighPopup);
  background-color: #ffffff;
  position: fixed;
  top: 20px;
  left: calc(50vw - var(--witdhPopup) / 2);
  z-index: 100;
  border: 2px solid #9c9c9c;
}

#popup .popup-msg {
  /* background-color: blueviolet; */
  width: 80%;
  height: 65%;
  position: relative;
  top: 0;
  left: 10%;
  display: flex;
  align-items: center;
  justify-content: space-between;
  border-bottom: 2px solid #cccccc;
}

#popup .popup-msg .popup-msg-icon {
  background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -672px -462px;
	width: 36px;
	height: 36px;
  /* margin-right: 10px; */
}

#popup .popup-msg .popup-msg-text {
	width: 260px;
}

#popup .popup-confirm {
  width: 80%;
  height: 35%;
  position: relative;
  left: 10%;
  display: flex;
  align-items: center;
  justify-content: flex-end;
}

.isHide {
  display: none;
}
</style>