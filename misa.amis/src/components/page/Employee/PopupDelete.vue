<template>
  <div :class="{ isHide: isHidePopup }">
    <div id="popup-model"></div>
    <div id="popup">
      <div class="popup-msg">
        <div class="popup-msg-icon"></div>
        <div class="popup-msg-text">Bạn có thực sự muốn xóa Nhân viên: {{ codeDel }} không?</div>
      </div>
      <div class="popup-confirm">
        <BaseButton
          @btnOnClick="btnNoOnClick"
          id="btnNo"
          btnText = "Không"
        />
        <BaseButton
          @btnOnClick="btnYesOnClick"
          id="btnYes"
          btnText = "Có"
        />
      </div>
    </div>
  </div>
</template>

<script>
import BaseButton from '../../base/BaseButton'

export default {
  name: 'PopupDelete',
  props: {
    isHidePopup: Boolean,
  },
  components: {
    BaseButton,
  },
  data() {
    return {
      idDel: '',
      codeDel: '',
    }
  },
  methods: {
    // khi ấn Yes, gọi lệnh xóa và đóng Popup
    // CreatedBy: NTANH (22/01/2021)
    btnYesOnClick() {
      this.$parent.deleteEmployee(this.idDel);
      this.$parent.closePopup();
    },

    // khi ấn No, không làm gì và đóng Popup
    // CreatedBy: NTANH (22/01/2021)
    btnNoOnClick() {
      this.$parent.closePopup();
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
  background: url('../../../assets/img/Sprites.64af8f61.svg') no-repeat -598px -463px;
	width: 36px;
	height: 37px;
  /* margin-right: 10px; */
}

#popup .popup-msg .popup-msg-text {
	width: 260px;
}

#popup .popup-confirm {
  width: 80%;
  height: 35%;
  /* background-color: cadetblue; */
  position: relative;
  left: 10%;
  display: flex;
  align-items: center;
  justify-content: space-between;
}

#popup .popup-confirm #btnNo {
  background-color: inherit;
  color: #5f5f5f;
  border: 1px solid #5f5f5f;
  font-family: Notosans-Semibold;
}

.isHide {
  display: none;
}
</style>