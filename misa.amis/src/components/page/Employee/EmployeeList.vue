<template>
  <div id="list-employee">
    <div class="top-of-content">
      <div class="category">
        <h2>Nhân viên</h2>
        <p><i class="icon-previous"></i>Tất cả danh mục</p>
      </div>
      <BaseButton
        @btnOnClick="openDialogInsert({EmployeeCode: employeeCodeMax})"
        id="btnAdd"
        btnText = "Thêm"
      />
    </div>


    <!--Table-->
    <div class="wrap-table">
      <div class="wrap-input">
        <i class="icon-search"></i>
        <input
          class="input-search-employee input input-with-icon" placeholder="Tìm theo tên, mã nhân viên,..."
          v-model="valueSearch"
          @change="searchEmployees"
        >
      </div>
      <div class="table">
        <table id="table_employee">
        <thead>
          <th style="width: 6%">MÃ NHÂN VIÊN</th>
          <th style="width: 13%">TÊN NHÂN VIÊN</th>
          <th style="width: 10%">CHỨC DANH</th>
          <th style="width: 10%">TÊN ĐƠN VỊ</th>
          <th style="width: 11%">SỐ TÀI KHOẢN</th>
          <th style="width: 10%">TÊN NGÂN HÀNG</th>
          <th style="width: 8%">TRẠNG THÁI</th>
          <th style="width: 11%">CHI NHÁNH</th>
          <th style="width: 5%">CHỨC NĂNG</th>
        </thead>
        <tbody id="tbody">
          <tr v-for="(employee, index) in employees" :key="index"
              @dblclick="openDialogUpdate(employee)">
            <td>{{ employee.EmployeeCode }}</td>
            <td>{{ employee.FullName }}</td>
            <td>{{ employee.PositionName }}</td>
            <td>{{ employee.DepartmentName }}</td>
            <td>{{ employee.BankAcountNumber }}</td>
            <td>{{ employee.BankName }}</td>
            <td>{{ employee.PropertyBankAcount }}</td>
            <td>{{ employee.BankBranch}}</td>
            <td style="color: blue">
              <button
                id="open-update-dialog"
                @click="openDialogUpdate(employee)"
              >Sửa</button>
              <div class="dropdown">
                <button class="dropbtn"><span class="icon-dropdown"></span></button>
                <div class="dropdown-content">
                  <button class="feature-option disable">Nhân bản</button>
                  <button
                    :id='employee.EmployeeCode'
                    class="feature-option"
                    @click="btnDeleteOnClick(employee.EmployeeId, employee.EmployeeCode)"
                  >Xóa</button>
                  <button
                    id="stopAction" class="feature-option"
                    @click="stopActionOnClick(employee)"
                  >Ngừng sử dụng</button>
                </div>
              </div>
            </td>
          </tr>
        </tbody>
      </table>
      </div>

      <div class="footer">
        <div class="row-number">
          Tổng số <b>{{ numberOfRow }}</b> bản ghi
        </div>
        <div class="footer-right-side">
          <select id="select-row-number" class="input">
            <option value="1">20 bản ghi trên 1 trang</option>
            <option value="2">30 bản ghi trên 1 trang</option>
          </select>
          <div class="paging">
            <div class="previous-page">Trước</div>
            <div class="page-number active">1</div>
            <div class="page-number">2</div>
            <div class="page-number">3</div>
            <div class="page-number">...</div>
            <div class="page-number">5</div>
            <div class="next-page">Sau</div>
          </div>
        </div>
      </div>
    </div>
    <TheDialog
      v-if="isShowDialog"
      :employeeCodeMax='employeeCodeMax'
      @closeDialog='closeDialog'
      ref="TheDialog"
    />
    <PopupDelete
      :isHidePopup='isHidePopup'
      ref="Popup"
    />
    <BasePopup
      :isHideBasePopup='isHideBasePopup'
      ref="BasePopup"
    />
  </div>
</template>

<script>
import axios from 'axios';
import TheDialog from '../Employee/TheDialog'
import BaseButton from '../../base/BaseButton'
import BasePopup from '../../base/BasePopup'
import PopupDelete from '../../page/Employee/PopupDelete'
export default {
  name: 'EmployeeList',
  props: {

  },
  components: {
    BaseButton,
    TheDialog,
    PopupDelete,
    BasePopup,
  },
  data() {
    return {
      isShowDialog: false,
      // isHideDialog: true,
      isHidePopup: true,
      isHideBasePopup: true,
      numberOfRow: 1,
      employeeCodeDelete: "",
      employees: [
        {
          employeeCode: 'LOADING',
        },
      ],
      employeeCodeMax: '',
      valueSearch: '',
    }
  },
  async created() {
    await axios.get("http://localhost:62735/api/v1/Employees")
    .then(response => {
      this.employees = response.data;
      this.getCodeMax();
      this.numberOfRow = response.data.length;
    })
    .catch(function (error){
      if(error.response){
        this.openBasePopup(error.response.data.UserMsg);
      }
    });
  },
  methods: {
    // mở dialog Innsert (hiện button Save, ẩn button Update)
    // CreatedBy: NTANH (22/01/2021)
    async openDialogInsert(employee) {
      // this.isHideDialog = false;
      await (this.isShowDialog = true);
      this.$refs.TheDialog.isHideBtnSave = false;
      this.$refs.TheDialog.isHideBtnUpdate = true;
      this.$refs.TheDialog.isHideErrorDepartment = true;
      this.$refs.TheDialog.isHideErrorCode = true;
      this.$refs.TheDialog.isHideErrorName = true;
      this.$refs.TheDialog.isHideErrorEmail = true;
      this.$refs.TheDialog.showDetailInsert(employee);
      this.$refs.TheDialog.btnContactOnClick();
    },

    // mở dialog Innsert (ẩn button Save, hiện button Update)
    // CreatedBy: NTANH (22/01/2021)
    async openDialogUpdate(employee) {
      // this.isHideDialog = false;
      await(this.isShowDialog = true);
      this.$refs.TheDialog.isHideBtnSave = true;
      this.$refs.TheDialog.isHideBtnUpdate = false;
      this.$refs.TheDialog.isHideErrorDepartment = true;
      this.$refs.TheDialog.isHideErrorCode = true;
      this.$refs.TheDialog.isHideErrorName = true;
      this.$refs.TheDialog.isHideErrorEmail = true;
      this.$refs.TheDialog.showDetailUpdate(employee);
      this.$refs.TheDialog.btnContactOnClick();
    },

    // đóng dialog và load lại data
    // CreatedBy: NTANH (22/01/2021)
    closeDialog(){
      // this.isHideDialog = true;
      this.isShowDialog= false;
      this.loadData();
    },

    // Mở Popup thông báo Xóa nhân viên
    // CreatedBy: NTANH (22/01/2021)
    openPopup() {
      this.isHidePopup = false;
    },

    // Đóng Popup thông báo xóa Nhân viên
    // CreatedBy: NTANH (22/01/2021)
    closePopup() {
      this.isHidePopup = true;
    },

    // Mở Base Popup
    // CreatedBy: NTANH (22/01/2021)
    openBasePopup(str) {
      this.isHideBasePopup = false;
      this.$refs.BasePopup.msg=str;
    },

    // Đóng Base Popup
    // CreatedBy: NTANH (22/01/2021)
    closeBasePopup() {
      this.isHideBasePopup = true;
    },

    // xử lý khi ấn vào "Xóa"
    // CreatedBy: NTANH (22/01/2021)
    btnDeleteOnClick(id, code){
      this.openPopup();
      this.$refs.Popup.idDel = id;
      this.$refs.Popup.codeDel = code;
    },

    // Xử lý khi ấn vào "Dừng sử dụng", chuyển thuộc PropertyBankAcount về 'Ngừng hoạt động'
    // CreatedBy: NTANH (22/01/2021)
    async stopActionOnClick(employee) {
      if(employee.PropertyBankAcount == 'Ngừng hoạt động') {
        this.openBasePopup("Đã ở tình trạng ngừng hoạt động rồi!");
      }
      else {
        employee.PropertyBankAcount = 'Ngừng hoạt động';
        await axios({
          method: 'PUT',
          url: 'http://localhost:62735/api/v1/Employees',
          data: employee
        }).then(
          this.openBasePopup("Tài khoản ngân hàng đã được ngừng sử dụng thành công!")
        )
        .catch(function (error){
          if(error.response){
            this.openBasePopup(error.response.data.UserMsg);
          }
        });
      }
    },

    // tìm kiếm Nhân viên theo Mã hoặc tên
    // CreatedBy: NTANH (22/01/2021)
    async searchEmployees() {
      // nếu trống thì lấy toàn bộ Nhân viên
      if(this.valueSearch.trim() == '')
      {
        await axios.get("http://localhost:62735/api/v1/Employees")
        .then(response => {
          this.employees = response.data;
        })
        .catch(function (error){
          if(error.response){
            this.openBasePopup(error.response.data.UserMsg);
          }
        });
      }
      else
      {
        // nếu có value thì lấy theo yêu cầu
        var url = "http://localhost:62735/api/v1/Employees/SearchByCodeAndName?str=" + this.valueSearch.trim();
        await axios.get(url)
        .then(response => {
          this.employees = response.data;
        })
        .catch(function (error){
          if(error.response){
            this.openBasePopup(error.response.data.UserMsg);
          }
        });
      }
    },

    // gọi xóa nhân viên theo ID
    // CreatedBy: NTANH (22/01/2021)
    async deleteEmployee(EmployeeId) {
      await axios({
        method: 'DELETE',
        url: 'http://localhost:62735/api/v1/Employees',
        data: {
          EmployeeId: EmployeeId,
        }
      })
      .catch(function (error){
          if(error.response){
            this.openBasePopup(error.response.data.UserMsg);
          }
        });
      this.loadData();
    },

    // Load lại data và lấy lại EmployeeCode lớn nhất
    // CreatedBy: NTANH (22/01/2021)
    async loadData() {
      await axios.get("http://localhost:62735/api/v1/Employees")
      .then(response => {
        this.employees = response.data;
        this.getCodeMax();
        this.numberOfRow = response.data.length;
      })
      .catch(function (error){
        if(error.response){
          this.openBasePopup(error.response.data.UserMsg);
        }
      });
    },

    // hàm lấy EmployeeCode lớn nhất trong DB
    // CreatedBy: NTANH (22/01/2021)
    async getCodeMax() {
      await axios.get("http://localhost:62735/api/v1/Employees/GetCode")
      .then(response => {
        var c = parseInt(response.data[response.data.length-1].slice(2)) + 1;
        if(c<99)
          this.employeeCodeMax = 'NV00' + c;
        else if(c<999)
          this.employeeCodeMax = 'NV0' + c;
        else
          this.employeeCodeMax = 'NV' + c;
        }
      )
      .catch(function (error){
        if(error.response){
          this.openBasePopup(error.response.data.UserMsg);
        }
      });
    },

    // Check trùng EmployeeCode, return: true - không trùng; false - có trùng
    // CreatedBy: NTANH (22/01/2021)
    checkDuplicateCode(code, func) {
      var numberDuplicate = 0;
      this.employees.forEach(e => {
        if(code == e.EmployeeCode) {
          numberDuplicate ++;
        }
      });
      if(func=='insert'){
        if(numberDuplicate > 0)
          return false;
        else
          return true;
      }
      else{
        if(numberDuplicate > 1)
          return false;
        else
          return true;
      }
    },

    // Check trùng IdentifyNumber, return: true - không trùng; false - có trùng
    // CreatedBy: NTANH (22/01/2021)
    checkDuplicateIdNumber(idNumber, func) {
      // nếu không nhập, không xét trùng.
      if(idNumber.trim()==''){
        return true;
      }
      // nếu có nhập, xử lý trùng
      else {
        var numberDuplicate = 0;
        this.employees.forEach(e => {
          if(idNumber == e.IdentifyNumber) {
            numberDuplicate ++;
          }
        });
        // console.log(numberDuplicate);
        if(func=='insert'){
          if(numberDuplicate > 0)
            return false;
          else
            return true;
        }
        else {
          if(numberDuplicate > 1)
            return false;
          else
            return true;
        }
      }
    },
  },
}
</script>

<style scoped>
.top-of-content {
  /* background-color: rgb(0, 211, 0); */
  width: 100%;
  height: 90px;
  margin-top: 0;
  display: flex;
  align-items: center;
  justify-content: space-between;
}

.category {
  margin-left: 16px;
}

#btnAdd {
  margin-right: 25px;
  width: 60px;
  height: 30px;
  /* background-color: #248c12; */
  border: none;
  border-radius: 8px;
  color: #ffffff;
  padding-left: 0;
  padding-right: 0;
}

.top-of-content p {
  margin: 0;
  color: #0060e7;
  /* font-weight: 600; */
}

.top-of-content .icon-previous {
  background: url('../../../assets/img/Sprites.64af8f61.svg') no-repeat -228px -362px;
	width: 8px;
	height: 12px;
  position: relative;
  left: 25px;
  top: 0px;
  display: inline-block;
  left: -2px;
  top: 1px;
}

.top-of-content h2 {
  margin-top: 10px;
  margin-bottom: 10px;
  margin-left: 10px;
}

.top-of-content p {
  margin-left: 10px;
  font-family: Notosans-Regular;
}

.icon-search {
  background: url('../../../assets/img/Sprites.64af8f61.svg') no-repeat -317px -148px;
  width: 16px;
  height: 16px;
  position: relative;
  display: inline-block;
  left: 208px;
  top: 3px;
}

/* Table */
.wrap-table {
  background-color: #ffffff;
  height: calc(100vh - 50px - 90px - 60px);
  margin-top: 15px;
  margin-left: 25px;
  width: 97%;
  /* position: relative; */
}

.wrap-input {
  /* background-color: red; */
  /* position: relative; */
  width: 100%;
}

.input-search-employee {
  margin-top: 10px;
  margin-bottom: 10px;
}

.table {
  width: 98%;
  height: calc(100vh - 250px);
  overflow: auto;
  margin-left: 15px;
}

#table_employee {
  border-collapse: collapse;
}

thead {
  border: 1px solid rgb(206, 206, 206);
}

#table_employee td, #table_employee th {
  border: 1px solid rgb(206, 206, 206);
  text-align: left;
  padding-left: 10px;
}

#table_employee th {
  background-color: rgb(233, 233, 233);
  height: 40px;
  position: sticky;
  top: -1px;
  border: 1px solid #c4c4c4;
  /* z-index: 2; */
}

#table_employee td {
  padding-left: 10px;
  height: 50px;
}

#table_employee tbody tr:hover {
  background-color: #f3f3f3;
}

#table_employee tr {
  background-color: #ffffff;
}

#table_employee #open-update-dialog {
  color: blue;
  font-family: Notosans-Semibold;
  border: none;
  outline: none;
  background-color: inherit;
  cursor: pointer;
}

#table_employee #open-update-dialog:hover {
  background-color: #f0f0f0;
}

/* feature-option */
.dropdown {
  position: relative;
  display: inline-block;
  /* top: -7px; */
}

.dropbtn {
  background-color: inherit;
  width: 25px;
  height: 20px;
  border: none;
  outline: none;
  cursor: pointer;
}

.icon-dropdown {
  display: inline-block;
  background: url('../../../assets/img/Sprites.64af8f61.svg') no-repeat -900px -365px;
	width: 8px;
	height: 6px;
}

.dropdown-content {
  display: none;
  position: absolute;
  right: 0;
  background-color: #ffffff;
  min-width: 130px;
  border: 1px solid #d4d4d4;
  z-index: 1;
}

.dropdown-content .feature-option {
  color: black;
  padding: 12px 16px;
  width: 130px;
  height: 40px;
  outline: none;
  border: none;
  background-color: #ffffff;
  cursor: pointer;
  text-align: left;
}

.dropdown-content .feature-option.disable {
  opacity: 0.5;
}

.dropdown-content .feature-option:hover
{
  background-color: #f1f1f1;
  color: rgb(0, 190, 0);
}

.dropdown-content .feature-option.disable:hover
{
  opacity: 0.5;
  background-color: inherit;
  color: black;
}

.dropdown:hover .dropdown-content {
  display: block;
}

.dropdown:hover .dropbtn {
  border: 1px solid blue;
}


/* Footer */
.footer {
  display: flex;
  align-items: center;
  justify-content: space-between;
  width: 100%;
  height: 40px;
  background-color: #ffffff;
}

.row-number {
  margin-left: 15px;
}

.footer-right-side {
  display: flex;
  align-items: center;
  justify-content: center;
}

.paging {
  display: flex;
  align-items: center;
  justify-content: center;
  margin-right: 20px;
}

.page-number {
  width: 20px;
  height: 20px;
  margin-left: 5px;
  text-align: center;
  cursor: pointer;
}

.page-number.active {
  border: 1px solid #a8a8a8;
  font-weight: 600;
}

.previous-page {
  margin-left: 10px;
  cursor: pointer;
}

.next-page {
  margin-left: 10px;
  cursor: pointer;
}
</style>