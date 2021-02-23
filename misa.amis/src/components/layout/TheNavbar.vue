<template>
  <div id="navbar">
    <div class="logo">
      <div class="expend-icon"></div>
      <div class="logo-icon"></div>
    </div>
      <div class="navbar-content">
        <a v-for="(navItem, index) in navItems" :key="index" class="nav-item">
          <div 
            class="nav-item-icon"
            :class="navItem.classIcon"
          ></div>
          <div class="nav-item-text">{{ navItem.text }}</div>
        </a>
      </div>
  </div>
</template>

<script>
export default {
  name: 'TheNavbar',
  props: {

  },
  components: {

  },
  methods: {
    
  },
  data() {
    return {
      navItems: [
        {
          text: 'Tổng quan',
          classIcon: 'icon-tongquan',
        },
        {
          text: 'Tiền mặt',
          classIcon: 'icon-tienmat'
        },
        {
          text: 'Tiền gửi',
          classIcon: 'icon-tiengui'
        },
        {
          text: 'Mua hàng',
          classIcon: 'icon-muahang'
        },
        {
          text: 'Bán hàng',
          classIcon: 'icon-banhang'
        },
        {
          text: 'Quản lý hóa đơn',
          classIcon: 'icon-quanlyhoadon'
        },
        {
          text: 'Kho',
          classIcon: 'icon-kho'
        },
        {
          text: 'Công cụ dụng cụ',
          classIcon: 'icon-congcudungcu'
        },
        {
          text: 'Tài sản cố định',
          classIcon: 'icon-taisancodinh'
        },
        {
          text: 'Thuế',
          classIcon: 'icon-thue'
        },
        {
          text: 'Giá thành',
          classIcon: 'icon-giathanh'
        },
        {
          text: 'Tổng hợp',
          classIcon: 'icon-tonghop'
        },
        {
          text: 'Ngân sách',
          classIcon: 'icon-ngansach'
        },
        {
          text: 'Báo cáo',
          classIcon: 'icon-baocao'
        },
        {
          text: 'Phân tích tài chính',
          classIcon: 'icon-phantichtaichinh'
        },
      ]
    }
  },
  computed: {

  },
}
</script>

<style scoped>
#navbar {
  background-color:#393a3e;
  height: 100vh;
  width: 200px;
  color: #ffffff;
}

.logo {
  /* background-color: blueviolet; */
  width: 100%;
  height: 60px;
  display: flex;
  align-items: center;
  justify-content: center;
}

.expend-icon {
  background-color: brown;
  background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -428px -92px;
	width: 16px;
	height: 16px;
  margin-right: 16px;
}

.logo-icon {
  width: 100px;
  height: 40px;
  background-image: url('../../assets/img/Logo_Module_TiengViet_White.66947422.svg');
  background-size: contain;
  background-repeat: no-repeat;
  background-position: center;
}

.nav-item {
  /* background-color: #51535a; */
  display:flex;
  padding-left:24px;
  height:44px;
  cursor:pointer;
  line-height:44px;
}

.nav-item:hover {
  background-color: #51535a;
}

.nav-item:focus {
  background-color:#87898f;
}

.nav-item:active {
  background-color:#494b52;
}

.nav-item-icon {
  align-self: center;
  margin-right: 10px;
  background-size: contain;
  width: 20px;
	height: 20px;
}

.nav-item-text {
  font-family: Notosans-Semibold;
}

.icon-tongquan {
  background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -33px -1587px;
}

.icon-tienmat {
  background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -78px -1588px;
}

.icon-tiengui {
  background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -121px -1590px;
}

.icon-muahang {
  background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -165px -1589px;
}

.icon-banhang {
  background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -206px -1588px;
}

.icon-quanlyhoadon {
  background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -254px -1589px;
}

.icon-kho {
  background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -294px -1589px;
}

.icon-congcudungcu {
  background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -339px -1590px;
}

.icon-taisancodinh {
  background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -382px -1589px;
}

.icon-thue {
  background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -427px -1591px;
}

.icon-giathanh {
  background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -471px -1590px;
}

.icon-tonghop {
  background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -514px -1590px;
}

.icon-ngansach {
  background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -427px -1664px;
}

.icon-baocao {
  background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -552px -1593px;
}

.icon-phantichtaichinh {
  background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -251px -1667px;
}
</style>