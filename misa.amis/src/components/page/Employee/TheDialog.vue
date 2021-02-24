<template>
  <div 
    id="dialog"
    :class="{ isHide: isHideDialog }"
  >
    <div id="dialog-model"></div>
    <div id="dialog-content">
      <!-- Dialog Header -->
      <div class="dialog-header">
          <div class="dialog-header-title">Thông tin nhân viên</div>
          <div class="dialog-header-feature">
            <input type="checkbox" name="pickRole" id="checkboxCustomer" class="checkbox" > Là khách hàng
            <input type="checkbox" name="pickRole" id="checkboxSupplier" class="checkbox" > Là nhà cung cấp
            <button class="dialog-header-info"><i class="icon-info"></i></button>
            <button class="dialog-header-close" @click="closeDialog"><i class="icon-close"></i></button>
          </div>
        </div>
      <!-- Dialog Body -->
      <div class="dialog-body">
        <div class="row">
          <div class="column-1">
            <div class="wrap-input wrap-1">
              <label for="code">Mã <span style="color: red">*</span></label><br>
              <input 
                type="text" name="code" class="input"
                v-model="employee.EmployeeCode"
                tabindex="1"
                autofocus = "on"
              >
              <small 
                id="error-code" class="error-msg"
                :class="{isHide:isHideErrorCode}"
              >Nhập đúng định dạng NV****</small>
            </div>
            <div class="wrap-input wrap-2">
              <label for="name">Tên <span style="color: red">*</span></label><br>
              <input 
                type="text" name="name" class="input"
                v-model="employee.FullName"
                tabindex="1"
              >
              <small
                id="error-name" class="error-msg"
                :class="{isHide:isHideErrorName}"
              >Không được để trống và không có ký tự đặc biệt!</small>
            </div>
          </div>
          <div class="column-2">
            <div class="wrap-input wrap-1">
              <label for="dob">Ngày sinh</label><br>
              <input 
                type="date" name="dob" class="input"
                v-model="employee.DateOfBirth"
                tabindex="2"
              >
            </div>
            <div class="wrap-input">
              <label for="gender">Giới tính</label><br>
              <input 
                type="radio" name="gender" value="1" class="input" 
                v-model="employee.Gender"
                tabindex="3"
              > <span class="text-gender">Nam</span>
              
              <input 
                type="radio" name="gender" value="0" class="input" 
                v-model="employee.Gender"
                tabindex="3"
              > <span class="text-gender">Nữ</span>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="column-1">
            <div class="wrap-input">
              <label for="department">Đơn vị <span style="color: red">*</span></label><br>
              <select name="department" class="input"
                :value="employee.DepartmentName"
                v-model="employee.DepartmentId"
                tabindex="5"
              >
                <option 
                  :value="department.departmentId"
                  v-for="(department, index) in departments" :key="index"
                >{{ department.departmentName }}</option>
              </select>
              <small 
                id="error-department" class="error-msg"
                :class="{isHide:isHideErrorDepartment}"
              >Hãy chọn một Đơn vị làm việc!</small>
            </div>
          </div>
          <div class="column-2">
            <div class="wrap-input">
              <label for="identifyNumber">Số CMND</label><br>
              <input 
                type="text" name="identifyNumber" class="input"
                v-model="employee.IdentifyNumber"
                tabindex="6"
              >
            </div>
            <div class="wrap-input">
              <label for="dateOfIdentifyNumber">Ngày cấp</label><br>
              <input 
                type="date" name="dateOfIdentifyNumber" class="input"
                v-model="employee.DateOfIdentifyNumber"
                tabindex="7"
              >
            </div>
          </div>
        </div>
        <div class="row">
          <div class="column-1">
            <div class="wrap-input">
              <label for="positionName">Chức danh</label><br>
              <input 
                type="text" name="positionName" class="input"
                v-model="employee.PositionName"
                tabindex="8"
              >
            </div>
          </div>
          <div class="column-2">
            <div class="wrap-input">
              <label for="placeOfIdentifyNumber">Nơi cấp</label><br>
              <input 
                type="text" name="placeOfIdentifyNumber" class="input"
                v-model="employee.PlaceOfIdentifyNumber" 
                tabindex="9" 
              >
            </div>
          </div>
        </div>


        <button 
          class="btn-contact btn-tab"
          :class="{ active: isActiveBtnContact }"
          @click="btnContactOnClick"
        >
          Liên hệ
        </button>
        <button
          class="btn-bank-acount btn-tab"
          :class="{ active: isActiveBtnBankAcount }"
          @click="btnBankAcountOnClick"
          tabindex="15"
        >
          Tài khoản ngân hàng
        </button>
        <div class="box-info">
          <div class="tab-info contact" :class="{ isHide: isHideContactTab }"
          >
            <div class="wrap-input">
              <label for="address">Địa chỉ</label><br>
              <input 
                type="text" name="address" class="input"
                v-model="employee.Address"
                tabindex="11"
              >
            </div>
            <div class="row-2">
              <div class="wrap-input">
                <label for="address">ĐT di động</label><br>
                <input 
                  type="text" name="mobilePhoneNumber" class="input"
                  v-model="employee.MobilePhoneNumber"
                  tabindex="12"
                >
              </div>
              <div class="wrap-input">
                <label for="landlinePhoneNumber">ĐT cố định</label><br>
                <input 
                  type="text" name="landlinePhoneNumber" class="input"
                  v-model="employee.LandlinePhoneNumber"
                  tabindex="13"
                >
              </div>
              <div class="wrap-input">
                <label for="email">Email</label><br>
                <input 
                  type="text" name="email" class="input"
                  v-model="employee.Email"
                  tabindex="14"
                >
                <small 
                  id="error-email" class="error-msg"
                  :class="{isHide:isHideErrorEmail}"  
                >Email phải có định dạng: example@gmail|yahoo|outlook.com !</small>
              </div>
            </div>
          </div>
          <div class="tab-info bank-acount" :class="{ isHide: isHideBankAcountTab }">
            <div class="table-bank-acount">
              <table id="table">
                <thead>
                  <th style="width: 18%">SỐ TÀI KHOẢN</th>
                  <th style="width: 20%">TÊN NGÂN HÀNG</th>
                  <th style="width: 25%">CHI NHÁNH</th>
                  <th style="width: 27%">TỈNH/TP CỦA NGÂN HÀNG</th>
                  <th style="width: 5%"></th>
                </thead>
                <tbody>
                  <tr>
                    <td>
                      <input 
                        type="text" class="input" name="bankAcountNumber"
                        v-model="employee.BankAcountNumber"
                        tabindex="16"
                      >
                    </td>
                    <td>
                      <input 
                        type="text" class="input" name="bankName"
                        v-model="employee.BankName"
                        tabindex="17"
                      >
                    </td>
                    <td>
                      <input 
                        type="text" class="input" name="bankBranch"
                        v-model="employee.BankBranch"
                        tabindex="18"
                      >
                    </td>
                    <td>
                      <input 
                        type="text" class="input" name="bankProvince"
                        v-model="employee.BankProvince"
                        tabindex="19"
                      >
                    </td>
                    <td style="text-align: center"><span class="icon-delete"></span></td>
                  </tr>
                </tbody>
              </table>
            </div>
            <div class="group-btn-bank-acount">
              <button style="margin-right: 10px; outline:none">Thêm dòng</button>
              <button style="outline: none">Xóa hết dòng</button>
            </div>
          </div>
        </div>
        <!-- Dialog footer -->
        <div class="dialog-footer">
          <BaseButton
            @btnOnClick="btnCancelOnClick"
            id="btnCancel"
            btnText = "Hủy"
            tabindex="20"
          />
          <div>
            <BaseButton
              @btnOnClick="btnUpdateOnClick"
              id="btnUpdate"
              :class="{ isHide: isHideBtnUpdate }"
              btnText = "Cất"
              tabindex="21"
            />
            <BaseButton
              @btnOnClick="btnSaveOnClick"
              id="btnSave"
              :class="{ isHide: isHideBtnSave }"
              btnText = "Cất và Thêm"
              tabindex="21"
            />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
import BaseButton from '../../base/BaseButton'


export default {
  name: 'TheDialog',
  props: {
    isHideDialog: Boolean,
    employeeCodeMax: String,
  },
  components: {
    BaseButton,
  },
  data() {
    return {
      isHideContactTab: false,
      isHideBankAcountTab: true,
      isActiveBtnContact: true,
      isActiveBtnBankAcount: false,
      isHideErrorCode: true,
      isHideErrorName: true,
      isHideErrorDepartment: true,
      isHideErrorEmail: true,
      isHideErrorIdentifyNumber: true,
      isHideBtnSave: false,
      isHideBtnUpdate: false,
      errorUserMsg: '',

      departments: [
        {
          departmentName: 'Phòng đào tạo',
          departmentId: '142cb08f-7c31-21fa-8e90-67245e8b283e',
        },
        {
          departmentName: 'Phòng kế toán',
          departmentId: '469b3ece-744a-45d5-957d-e8c757976496',
        },
        {
          departmentName: 'Phòng công nghê',
          departmentId: '4e272fc4-7875-78d6-7d32-6a1673ffca7c',
        },
        {
          departmentName: 'Phòng Marketing',
          departmentId: '17120d02-6ab5-3e43-18cb-66948daf6128',
        },
      ],
      employee: {},
    }
  },
  methods: {

    // load Employee muốn sửa thông tin vào, format dữ liệu nếu cần
    // CreatedBy: NTANH (22/01/2021)
    showDetailUpdate(employee){
      // console.log('employee trong ham showDetail trong Dialog.Vue', employee);
      employee.DateOfBirth = this.formatDate(employee.DateOfBirth);
      employee.DateOfIdentifyNumber = this.formatDate(employee.DateOfIdentifyNumber);
      this.employee = employee;
    },

    // Load EmployeeCode mới vào khi thêm mới
    // CreatedBy: NTANH (22/01/2021)
    showDetailInsert(employee){
      // console.log('employee trong ham showDetail trong Dialog.Vue', employee);
      employee.IdentifyNumber = "";
      employee.Gender = 1;
      this.employee = employee;
    },

    // đóng Dialog và load lại dữ liệu trong TheContent
    // CreatedBy: NTANH (22/01/2021)
    closeDialog() {
      this.$emit('closeDialog');
      this.$parent.loadData();
    },

    // Đóng dialog và load lại data
    // CreatedBy: NTANH (22/01/2021)
    btnCancelOnClick() {
      this.$emit('closeDialog');
      this.$parent.loadData();
    },

    // xử lý Sửa nhân viên
    // CreatedBy: NTANH (22/01/2021)
    async btnUpdateOnClick() {
      // check sau khi sửa mà bị trùng EmployeeCode
      if(this.$parent.checkDuplicateCode(this.employee.EmployeeCode, 'update')==false) {
        this.$parent.openBasePopup('Mã nhân viên này đã tồn tại trên hệ thống!');
        this.$parent.loadData();
      }
      // check sau khi sửa mà bị trùng IdentifyNumber
      else if(this.$parent.checkDuplicateIdNumber(this.employee.IdentifyNumber, 'update')==false) {
        this.$parent.openBasePopup('Số CMND đã tồn tại trên hệ thống!');
        this.$parent.loadData();
      }
      else {
        // Nếu không trùng thì Validate các trường dữ liệu
        if(this.validateData()==false) {
          // dữ liệu không hợp lệ, cảnh báo người dùng.
        }
        else {
          await axios({
            method: 'PUT',
            url: 'http://localhost:62735/api/v1/Employees',
            data: this.employee
          })
          .then(
            this.$parent.openBasePopup('Cập nhật nhân viên thành công!')
          )
          .catch(function (error){
              if(error.response){
                this.$parent.openBasePopup(error.response.data.UserMsg);
              }
            });
          this.closeDialog();
          this.$parent.loadData();
        }
      }
    },

    // xử lý khi ấn vào Lưu Nhân viên khi thêm mới
    // CreatedBy: NTANH (22/01/2021)
    async btnSaveOnClick() {
      // check sau khi sửa mà bị trùng EmployeeCode
      if(this.$parent.checkDuplicateCode(this.employee.EmployeeCode, 'insert')==false) {
        this.$parent.openBasePopup('Mã nhân viên này đã tồn tại trên hệ thống!');
        this.$parent.loadData();
      }
      // check sau khi sửa mà bị trùng IdentifyNumber
      else if(this.$parent.checkDuplicateIdNumber(this.employee.IdentifyNumber, 'insert')==false) {
        this.$parent.openBasePopup('Số CMND đã tồn tại trên hệ thống!');
        this.$parent.loadData();
      }
      else {
        // validate dữ liệu trước khi cho phép thêm
        if(this.validateData() == false) {
          // validate ko hop le.
        }
        // nếu phù hợp nghiệp vụ thì cho thêm
        else {
          await axios.post("http://localhost:62735/api/v1/Employees", this.employee)
          .then(
            this.$parent.openBasePopup('Thêm nhân viên thành công!')
          )
          .catch(function (error){
            if(error.response){
              this.$parent.openBasePopup(error.response.data.UserMsg);
            }
          });
          // đóng dialog và load lại data trong TheContent
          this.$parent.closeDialog();
          this.$parent.loadData();
        }
      }
    },

    // Mở tab Contact khi ấn vào tab Liên Hệ
    // CreatedBy: NTANH (22/01/2021)
    btnContactOnClick() {
      this.isHideContactTab = false;
      this.isHideBankAcountTab = true;
      this.isActiveBtnContact = true;
      this.isActiveBtnBankAcount = false;
    },

    // mở tab BankAcount khi ấn vào tab Tài Khoản Ngân Hàng
    // CreatedBy: NTANH (22/01/2021)
    btnBankAcountOnClick() {
      this.isHideContactTab = true;
      this.isHideBankAcountTab = false;
      this.isActiveBtnContact = false;
      this.isActiveBtnBankAcount = true;
    },

    // Hàm Validate định dạng dữ liệu nhập vào, return: True - hợp lệ; False: không hợp lệ
    // CreatedBy: NTANH (22/01/2021)
    validateData() {
      const formFullName = /[a-zA-ZàáãạảăắằẳẵặâấầẩẫậèéẹẻẽêềếểễệđìíĩỉịòóõọỏôốồổỗộơớờởỡợùúũụủưứừửữựỳỵỷỹýÀÁÃẠẢĂẮẰẲẴẶÂẤẦẨẪẬÈÉẸẺẼÊỀẾỂỄỆĐÌÍĨỈỊÒÓÕỌỎÔỐỒỔỖỘƠỚỜỞỠỢÙÚŨỤỦƯỨỪỬỮỰỲỴỶỸÝ\s]+$/;
      const formEmail = /^[a-zA-Z0-9._]+(@gmail.com|@outlook.com|@yahoo.com)$/;
      const formEmployeeCode = /^NV[0-9]{4}$/;

      var failed = 0;
      // Validate FullName: 
      if ((formFullName.test(this.employee.FullName) == false) || (this.employee.FullName == null)) {
        this.isHideErrorName = false;
        failed++;
      } 
      else if (this.employee.FullName.trim() == '') {
        this.isHideErrorName = false;
        failed++;
      }
      else {
        this.isHideErrorName = true;
      }

      // validate EmployeeCode:
      if((formEmployeeCode.test(this.employee.EmployeeCode.trim())==false) || (this.employee.EmployeeCode.trim()=='')) {
        this.isHideErrorCode = false;
        failed ++;
      }
      else {
        this.isHideErrorCode = true;
      }

      // validate Department:
      if((this.employee.DepartmentId==null)) {
        this.isHideErrorDepartment = false;
        failed ++;
      }
      else {
        this.isHideErrorDepartment = true;
      }

      // validate Email:
      if(this.employee.Email != null){
        if(this.employee.Email.trim() == ""){
          this.isHideErrorEmail = true;
        }
        else {
          if (formEmail.test(this.employee.Email.trim())==false) {
            this.isHideErrorEmail = false;
            failed ++;
          }
          else {
            this.isHideErrorEmail = true;
          }
        }
      }
      else {
        this.isHideErrorEmail = true;
      }
      
      // nếu không có lỗi thì không hiện cảnh báo
      if(failed == 0) {
        this.isHideErrorName = true;
        this.isHideErrorCode = true;
        this.isHideErrorDepartment = true;
        this.isHideErrorEmail = true;
        this.isHideErrorIdentifyNumber = true;
        return true;
      }
      else {
        return false;
      }
    },

    // định dạng ngày về yyyy-MM-dd
    // CreatedBy: NTANH (22/01/2021)
    formatDate(date){
      var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2) 
        month = '0' + month;
    if (day.length < 2) 
        day = '0' + day;

    return [year, month, day].join('-');
    }
  },
  computed: {
    
  },
}
</script>

<style scoped>
#dialog {
  /* z-index: 20; */
}

.isHide {
  display: none;
}

#dialog-model {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  background-color: black;
  opacity: 0.4;
}

#dialog-content {
  --widthDialog: 900px;
  --heightDialog: 600px;
  width: var(--widthDialog);
  height: var(--heightDialog);
  background-color: #ffffff;
  border: 1px solid #929292;
  position: fixed;
  top: calc(50% - var(--heightDialog) / 2);
  left: calc(50% - var(--widthDialog) / 2);
}

/* Dialog Header */
.dialog-header {
  /* background-color: #d8a4a4; */
  position: relative;
  height: 40px;
  line-height: 40px;
  padding-left: 16px;
  display: flex;
  margin-bottom: 20px;
}

.dialog-header-title  {
  /* background-color: tomato; */
  font-family: Notosans-Bold;
  position: absolute;
  top: 10px;
  left: 30px;
  font-size: 24px;
}

.dialog-header-feature {
  /* background-color: teal; */
  position: relative;
  top: 10px;
  left: 300px;
}

.dialog-header-close {
  background-color: transparent;
  position: absolute;
  top: 0px;
  right: -322px;
  width: 24px;
  height: 24px;
  /* border-radius: 50%; */
  cursor: pointer;
  align-items: center;
  border: none;
  font-size: 24px;
  line-height: 24px;
}

.dialog-header-info {
  background-color: transparent;
  position: absolute;
  top: 0px;
  right: -285px;
  width: 24px;
  height: 24px;
  /* border-radius: 50%; */
  cursor: pointer;
  align-items: center;
  border: none;
  font-size: 24px;
  line-height: 24px;
}

.dialog-header-close:focus, .dialog-header-info:focus {
  border: none;
  outline: none;
}

.icon-close {
  background: url('../../../assets/img/Sprites.64af8f61.svg') no-repeat -147px -147px;
	width: 18px;
	height: 18px;
  display: inline-block;
}
.icon-info {
  background: url('../../../assets/img/Sprites.64af8f61.svg') no-repeat -89px -145px;
	width: 22px;
	height: 22px;
  display: inline-block;
}

.checkbox {
  width: 20px;
  height: 20px;
  position: relative;
  top: 5px;
}

/* Dialog Body */
.dialog-body {
  /* background-color: #9380db; */
  width: 100%;
  height: calc(100% - 40px);
  position: relative;
}

.row {
  /* background-color: #a58383; */
  width: calc(100% - 20px);
  height: 60px;
  margin-top: 10px;
  display: flex;
  padding-left: 20px;
  padding-right: 20px;
}

.column-1 {
  /* background-color: #6fd1a8; */
  display: flex;
  height: 60px;
  width: 48%;
  margin-right: 16px;
}

.column-2 {
  /* background-color: #6fd1a8; */
  display: flex;
  height: 60px;
  width: 48%;
}

label {
  font-family: Notosans-Semibold;
}

.input {
  width: 100%;
  height: 35px;
}

.wrap-1 {
  width: 160px;
}

.wrap-2 {
  width: 273px;
}

.input[name="department"],
.input[name="positionName"], 
.input[name="placeOfIdentifyNumber"] {
  width: 418px;
}

.input[name="gender"] {
  width: 20px;
  height: 20px;
  margin-top: 10px;
  margin-left: 15px;
}

.input[name="name"] {
  margin-left: 5px;
  width: 257px;
}

.input[name="identifyNumber"] {
  width: 244px;
  margin-right: 6px;
}

label[for="gender"] {
  margin-left: 17px;
}

.text-gender {
  display: inline-block;
  position: relative;
  top: -5px;
}

/* box-info */
.btn-tab {
  border: 1px solid #dadada;
  background-color: inherit;
  position: absolute;
  cursor: pointer;
  top: 216px;
}

.btn-tab:checked, .btn-tab:focus {
  outline: none;
}

.btn-tab.active {
  background-color: #cae4fb;
  height: 40px;
  top: 211px;
}

.btn-contact {
  width: 80px;
  height: 35px;
  left: 24px; 
}

.btn-bank-acount {
  width: 150px;
  height: 35px;
  left: 110px;
}

/* box-info */
.box-info {
  /* background-color: #72bcd3; */
  width: calc(100% - 44px);
  height: 200px;
  margin-left: 24px;
  margin-top: 50px;
  box-sizing: border-box;
  padding-left: 14px;
  padding-right: 14px;
  border: 1px solid #c5c5c5;
  padding-top: 20px;
}

.box-info .tab-info {
  width: 100%;
  height: 200px;
}

.box-info .contact {
  /* background-color: #eb70eb; */
  height: 100%;
  /* display: none; */
}

.box-info .bank-acount {
  /* background-color: #88e09b; */
  height: 100%;
  /* display: none; */
}

.row-2 {
  /* background-color: lightgreen; */
  width: 100%;
  height: 58px;
  margin-top: 10px;
  display: flex;
}

.row-2 .wrap-input {
  margin-right: 10px;
}

/* box bank acount */
.table-bank-acount {
  background-color: lightsalmon;
  margin-bottom: 10px;
}

.table-bank-acount #table {
  border-collapse: collapse;
  background-color: #edeef1;
  width: 100%;
}

.table-bank-acount #table tr, td, th {
  border: 1px solid #afafaf;
}

.table-bank-acount #table tr {
  height: 40px;
  background-color: #f4f5f9;
}

.table-bank-acount #table th {
  text-align: left;
  font-family: Notosans-Semibold;
  padding-left: 10px;
}

.table-bank-acount #table tbody input {
  width: 84%;
  height: 30px;
  margin-left: 8%;
  font-size: 12px;
  margin-bottom: 3px;
}

.table-bank-acount .icon-delete {
  display: inline-block;
  background: url('../../../assets/img/Sprites.64af8f61.svg') no-repeat -464px -313px;
	width: 15px;
	height: 15px;
  cursor: pointer;
}

.bank-acount .group-btn-bank-acount button {
  background-color: #ffffff;
  border: 1px solid #a7a7a7;
  border-radius: 4px;
  height: 25px;
  padding-left: 20px;
  padding-right: 20px;
  font-family: Notosans-Semibold;
  cursor: pointer;
}

/* Dialog Footer */
.dialog-footer {
  /* background-color: khaki; */
  position: relative;
  top: 19px;
  left: 24px;
  width: 860px;
  height: 70px;
  border-top: 1px solid #dadada;
  display: flex;
  align-items: center;
  justify-content: space-between;
}

.dialog-footer #btnCancel, #btnUpdate {
  background-color: inherit;
  color: #252525;
  font-family: Notosans-Semibold;
  border: 1px solid #636363;
}

.dialog-footer #btnCancel:hover, #btnUpdate:hover{
  background-color: #dadada;
}

.error-msg {
  color: red;
  font-size: 10px;
  font-style: italic;
}
</style>