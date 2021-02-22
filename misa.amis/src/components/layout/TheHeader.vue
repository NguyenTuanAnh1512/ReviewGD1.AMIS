<template>
  <div id="header">
    <select name="company" id="company">
      <option value="1">CÔNG TY TNHH NƯỚC UỐNG TINH KHIẾT SÀI GÒN</option>
    </select>
    <div id="feature">
      <i class="icon-search"></i>
      <input class="input-quick-search input input-with-icon" placeholder="nhập từ khóa để tìm kiếm">
      <div class="feature-icon icon-tuychon"></div>
      <div class="feature-icon icon-caidat"></div>
      <div class="feature-icon icon-tinnhan"></div>
      <div class="feature-icon icon-cauhoi"></div>
      <div class="feature-icon icon-thongbao"></div>
      <i class="icon-user"></i>
      <select name="user" id="user">
        <option value="1">Nguyễn Tuấn Anh</option>
      </select>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Header',
  props: {

  },
  components: {

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

<style scoped>
#header {
  /* background-color: aquamarine; */
  position: absolute;
  top: 0;
  left: 200px;
  height: 50px;
  width: calc(100% - 200px);
  display: flex;
  align-items: center;
  justify-content: space-between;
}

#company {
  /* background-color: crimson; */
  height: 40px;
  padding-right: 14px;
  padding-left: 8px;
  margin-left: 16px;
  border: none;
  border-radius: 4px;
  font-family: Notosans-Semibold;
}

#company:hover {
  background-color: #d1d1d1;
}

#company:focus {
  outline: none;
}

#feature {
  /* background-color: darkblue; */
  height: 40px;
  /* width: 500px; */
  display: flex;
  align-items: center;
  justify-content: center;
}

#feature .input-quick-search {
  height: 32px;
  margin-top: 0;
  margin-right: 10px;
}

.icon-search {
  background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -317px -148px;
  width: 16px;
  height: 16px;
  position: relative;
  left: 208px;
  top: 0px;
}

#user {
  /* background-color: darkgoldenrod; */
  height: 40px;
  padding-right: 14px;
  padding-left: 8px;
  border: none;
  border-radius: 4px;
  font-family: Notosans-Semibold;
  padding-left: 50px;
  margin-right: 16px;
}

#user:hover {
  background-color: #d1d1d1;
}

#user:focus {
  outline: none;
}

.icon-user {
  background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -352px -894px;
  border-radius: 50%;
	width: 32px;
	height: 32px;
  position: relative;
  left: 45px;
}

#feature .feature-icon {
  /* background-color: darkgoldenrod; */
  width: 30px;
  height: 30px;
  margin-left: 10px;
}

#feature .feature-icon:hover {
  background-color: #d1d1d1;
}

.icon-tuychon {
  background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -565px -27px;
}
.icon-caidat {
  background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -29px -141px;
}
.icon-tinnhan {
  background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -895px -27px;
}
.icon-cauhoi {
  background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -728px -28px;
}
.icon-thongbao {
  background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -784px -27px;
}
</style>