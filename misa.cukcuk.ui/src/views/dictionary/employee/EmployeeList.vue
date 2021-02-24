<template>
    <div class="employee-list">
        <EmployeeListDetail
            ref="dialog"
            id="m"
            @closeDialog="closeDialog"
            :isHide="isHideParent"
            @onEmployeeDelete="onEmployeeDelete"
            @loadNewEmployee="loadNewEmployee"
            @loadData="loadData"
            :data="employee"
        />

        <div class="employee-list__header">
            <div class="header__breadcrumb">
                <div class="breadcrumb__title">Danh mục</div>
                <div class="breadcrumb__item">
                    Nhân viên
                </div>
            </div>
            <div class="header__filter">
                <div class="filter__title">Lọc nhanh</div>
                <select
                    class="quick-filter-combobox m-combobox"
                    @change="filterEmployee($event)"
                >
                    <option value="">--Tất cả--</option>
                    <option
                        v-for="workStatus in workStatuses"
                        :key="workStatus.WorkStatusId"
                        :value="workStatus.WorkStatusId"
                        >{{ workStatus.WorkStatusName }}</option
                    >
                </select>
            </div>
            <button class="btn-return-to-original-settings m-btn">
                Quay lại thiết lập ban đầu
            </button>
            <button class="btn-feedback m-btn__icon">
                <div class="m-icon icon__feedback"></div>
                <span>Phản hồi</span>
            </button>
        </div>
        <div class="employee-list__content">
            <div class="toolbar">
                <button
                    title="Ctrl 1"
                    class="m-btn__icon"
                    id="btnAdd"
                    @click="btnAddClick"
                >
                    <div class="m-icon m-icon--add"></div>
                    <span>Thêm</span>
                </button>
                <button class="m-btn__icon isDisabled">
                    <div class="m-icon m-icon--duplicate"></div>
                    <span>Nhân bản</span>
                </button>
                <button
                    title="Ctrl E"
                    class="m-btn__icon"
                    @click="btnUpdateClick()"
                >
                    <div class="m-icon m-icon--view"></div>
                    <span>Xem</span>
                </button>
                <button
                    title="Ctrl E"
                    class="m-btn__icon"
                    id="btnUpdate"
                    @click="btnUpdateClick()"
                >
                    <div class="m-icon m-icon--update"></div>
                    <span>Sửa</span>
                </button>
                <button
                    title="Ctrl D"
                    class="m-btn__icon"
                    @click="btnDeleteClick()"
                >
                    <div class="m-icon m-icon--delete"></div>
                    <span>Xóa</span>
                </button>
                <button class="m-btn__icon" @click="loadData">
                    <div class="m-icon m-icon--inner"></div>
                    <span>Nạp</span>
                </button>
                <button class="m-btn__icon isDisabled">
                    <div class="m-icon m-icon--help"></div>
                    <span>Giúp</span>
                </button>
            </div>
            <div class="grid">
                <div class="grid__content">
                    <!-- <div class="grid__overflow">
          <div class="grid__header">
            <div class="grid__header__item">
              <div class="grid__header-title">Tên đăng nhập</div>
              <div class="grid__header-filter">
                <button class="grid__header-split">*</button>
                <input type="text" class="grid__header-textbox" />
              </div>
            </div>
            <div class="grid__header__item flex-2">
              <div class="grid__header-title">Tên nhân viên</div>
              <div class="grid__header-filter">
                <button class="grid__header-split">*</button>
                <input type="text" class="grid__header-textbox" />
              </div>
            </div>
            <div class="grid__header__item">
              <div class="grid__header-title">Số điện thoại</div>
              <div class="grid__header-filter">
                <button class="grid__header-split">*</button>
                <input type="text" class="grid__header-textbox" />
              </div>
            </div>
            <div class="grid__header__item">
              <div class="grid__header-title">giới tính</div>
              <div class="grid__header-filter">
                <button class="grid__header-split">*</button>
                <input type="text" class="grid__header-textbox" />
              </div>
            </div>
            <div class="grid__header__item">
              <div class="grid__header-title mr-12px">
                Ngày sinh
              </div>
              <div class="grid__header-filter">
                <button class="grid__header-split">*</button>
                <input type="date" class="grid__header-textbox" />
              </div>
            </div>

            <div class="grid__header__item">
              <div class="grid__header-title">
                Trạng thái làm việc
              </div>
              <div class="grid__header-filter">
                <button class="grid__header-split">*</button>
                <input type="text" class="grid__header-textbox" />
              </div>
            </div>
            <div class="grid__header__track"></div>
          </div>
          <table class="grid__body">
            <tbody ref="gridContent">
              <tr
                v-for="employee in employees"
                :key="employee.EmployeeId"
                @click="tableRowClick"
                @dblclick="rowDoubleClick(employee)"
                :data-id="employee.EmployeeId"
                :data-code="employee.EmployeeCode"
              >
                <td>
                  {{ employee.EmployeeCode }}
                </td>
                <td class="flex-2">{{ employee.FullName }}</td>
                <td>{{ employee.PhoneNumber }}</td>
                <td>{{ formatGender(employee.Gender) }}</td>
                <td>{{ formatDate(employee.DateOfBirth) }}</td>
                <td>{{ employee.WorkStatusName }}</td>
              </tr>
            </tbody>
          </table>
        </div> -->

                    <table id="tblEmployee">
                        <thead class="grid__header">
                            <tr>
                                <td>
                                    <div class="grid__header-title">
                                        Tên đăng nhập
                                    </div>
                                    <div class="grid__header-filter">
                                        <button class="grid__header-split">
                                            *
                                        </button>
                                        <input
                                            type="text"
                                            class="grid__header-textbox"
                                        />
                                    </div>
                                </td>
                                <td>
                                    <div class="grid__header-title">
                                        Tên nhân viên
                                    </div>
                                    <div class="grid__header-filter">
                                        <button class="grid__header-split">
                                            *
                                        </button>
                                        <input
                                            type="text"
                                            class="grid__header-textbox"
                                        />
                                    </div>
                                </td>
                                <td>
                                    <div class="grid__header-title">
                                        Số điện thoại
                                    </div>
                                    <div class="grid__header-filter">
                                        <button class="grid__header-split">
                                            *
                                        </button>
                                        <input
                                            type="text"
                                            class="grid__header-textbox"
                                        />
                                    </div>
                                </td>
                                <td>
                                    <div class="grid__header-title">
                                        giới tính
                                    </div>
                                    <div class="grid__header-filter">
                                        <button class="grid__header-split">
                                            *
                                        </button>
                                        <input
                                            type="text"
                                            class="grid__header-textbox"
                                        />
                                    </div>
                                </td>
                                <td>
                                    <div class="grid__header-title mr-12px">
                                        Ngày sinh
                                    </div>
                                    <div class="grid__header-filter">
                                        <button class="grid__header-split">
                                            *
                                        </button>
                                        <input
                                            type="date"
                                            class="grid__header-textbox"
                                        />
                                    </div>
                                </td>
                                <td>
                                    <div class="grid__header-title">
                                        Trạng thái làm việc
                                    </div>
                                    <div class="grid__header-filter">
                                        <button class="grid__header-split">
                                            *
                                        </button>
                                        <input
                                            type="text"
                                            class="grid__header-textbox"
                                        />
                                    </div>
                                </td>
                            </tr>
                        </thead>
                        <tbody ref="gridContent">
                            <tr
                                class="grid__cell"
                                v-for="employee in employees"
                                :key="employee.EmployeeId"
                                @click="tableRowClick"
                                @dblclick="rowDoubleClick(employee)"
                                :data-id="employee.EmployeeId"
                                :data-code="employee.EmployeeCode"
                            >
                                <td class="grid__column">
                                    {{ employee.EmployeeCode }}
                                </td>
                                <td class="grid__column">
                                    {{ employee.FullName }}
                                </td>
                                <td class="grid__column">
                                    {{ employee.PhoneNumber }}
                                </td>
                                <td class="grid__column">
                                    {{ formatGender(employee.Gender) }}
                                </td>
                                <td class="grid__column">
                                    {{ formatDate(employee.DateOfBirth) }}
                                </td>
                                <td class="grid__column">
                                    {{ employee.WorkStatusName }}
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>

                <div class="grid__paging">
                    <div class="paging__btn">
                        <div class="paging__icon icon__first-page"></div>
                    </div>
                    <div class="paging__btn">
                        <div class="paging__icon icon__prev-page"></div>
                    </div>
                    <div class="select__page">
                        <span>Trang</span>
                        <input type="text" class="txt-select__page" value="1" />
                        <span>Trên 1</span>
                    </div>
                    <div class="paging__btn">
                        <div class="paging__icon icon__next-page"></div>
                    </div>
                    <div class="paging__btn">
                        <div class="paging__icon icon__last-page"></div>
                    </div>
                    <div class="paging__btn">
                        <div class="paging__icon icon__refresh"></div>
                    </div>
                    <select class="m-combobox cbo-slect-number-per-page">
                        <option value="">25</option>
                        <option value="">50</option>
                        <option value="">100</option>
                    </select>
                    <div class="result-display">
                        Hiển thị 1 - 17 trên 17 kết quả
                    </div>
                </div>
            </div>
        </div>
        <DialogConfirm
            ref="dialogConfirm"
            :employeeId="employeeId"
            :isHide="isHideDialogConfirm"
            :message="message"
            @closeDialogConfirm="isHideDialogConfirm = $event"
            @onEmployeeDelete="onEmployeeDelete"
        />
    </div>
</template>

<script>
import EmployeeListDetail from './EmployeeListDetail'
import DialogConfirm from '@/components/dialogs/DialogConfirm'

import axios from 'axios'
export default {
    components: {
        EmployeeListDetail,
        DialogConfirm,
    },
    data() {
        return {
            isHideParent: true,
            isHideDialogConfirm: true,
            message: '',
            employees: [],
            employee: {
                Email: '',
            },
            employeeId: '',
            workStatuses: [],
            newCode: '',
        }
    },
    methods: {
        /**
         * Hàm bật lại dialog khi thêm mới
         */
        loadNewEmployee() {
            this.btnAddClick()
        },
        /**
         * Hàm thực hiện load lại dữ liệu
         * CreatedBy: TLKhanh(22/2/2021)
         */
        async loadData() {
            try {
                var workStatuses = await axios.get(
                    'http://localhost:52690/api/v1/workstatuss'
                )
                this.workStatuses = workStatuses.data
                var response = await axios.get(
                    'http://localhost:52690/api/v1/Employees'
                )
                this.employees = response.data
                // Xử lý slect row đầu tiên
                setTimeout(() => {
                    var tbody = document.querySelector('tbody')
                    var row = document.querySelector('.row-selected')
                    if (row) {
                        row.classList.remove('row-selected')
                    }
                    tbody.firstChild.classList.add('row-selected')
                }, 0)
            } catch (error) {
                console.log(error)
            }
        },
        /**
         * Hàm focus button đầu tiên của Dialog
         */
        focusButton() {
            setTimeout(() => {
                this.$refs.dialogConfirm.$refs.firstButton.focus()
            }, 0)
        },
        /**
         * Hàm focus input
         * CreatedBy: TLKhanh (20/2/2021)
         */
        focusInput() {
            setTimeout(() => {
                this.$refs.dialog.$refs.employeeCode.focus()
            }, 0)
        },
        /**
         * Hàm filter nhanh
         * CreatedBy TLKhanh (19/2/2021)
         */
        async filterEmployee(event) {
            var workStatusId = event.target.value
            try {
                var employee = await axios.get(
                    `http://localhost:52690/api/v1/Employees/filter?workStatus=${workStatusId}`
                )
                this.employees = employee.data
            } catch (error) {
                console.log(error)
            }
        },
        // hàm đóng dialog
        closeDialog(value) {
            this.isHideParent = value
        },
        /**
         * Hàm mở dialog khi click button add
         * CreatedBy TLKhanh (19/2/2021)
         */
        async btnAddClick() {
            try {
                var response = await axios.get(
                    'http://localhost:52690/api/v1/Employees/max-code'
                )
                var code = response.data.EmployeeCode
                var codeLength = code.length
                var num = (parseInt(code.split('NV')[1]) + 1).toString()
                var newCode = 'NV'
                for (var i = 0; i < codeLength - num.length - 2; i++) {
                    newCode = newCode + '0'
                }
                newCode = newCode + num
                this.employee = {
                    EmployeeCode: newCode,
                }
            } catch (error) {
                console.log(error)
            }
            this.isHideParent = false
            this.focusInput()
        },
        /**
         * Hàm xử lý khi row double click
         * CreatedBy: TLKhanh (19/2/2021)
         */
        rowDoubleClick(employee) {
            this.isHideParent = false
            var firstInput = document.querySelector('#txtEmployeeCode')
            firstInput.focus()
            for (var key in employee) {
                if (
                    key.toLowerCase().indexOf('date') !== -1 &&
                    employee[key] != null
                ) {
                    employee[key] = employee[key].slice(0, 10)
                }
            }
            this.employee = employee
            this.focusInput()
        },
        /**
         * Hàm xử lý khi row table click
         * CreatedBy: TLKhanh (19/2/2021)
         */
        tableRowClick(event) {
            event.preventDefault()
            var element = event.target
            if (element.localName == 'td') {
                element = element.parentElement
            }
            var row = document.querySelector('.row-selected')
            if (row) {
                row.classList.remove('row-selected')
            }

            element.classList.add('row-selected')
        },
        /**
         * Hàm định dạng lại giới tính 0 contrai, 1 con gái, 2 khác
         * @param {int} gender
         * CreatedBy TLKhanh (19/2/2021)
         */
        formatGender(gender) {
            var g = parseInt(gender)
            var genderName =
                g == 1
                    ? 'Nữ'
                    : g == 0
                    ? 'Nam'
                    : g == 2
                    ? 'Khác'
                    : 'Không xác định'
            return genderName
        },
        /**
         *Hàm định dạng lại ngày sinh
         * @param {string} d
         * CreatedBy TLKhanh (19/2/2021)
         */
        formatDate(d) {
            if (d == null) return 'Chưa nhập'
            var date = new Date(d)
            var day = date.getDate() > 9 ? date.getDate() : '0' + date.getDate()
            var month =
                date.getMonth() + 1 > 9
                    ? date.getMonth() + 1
                    : '0' + (date.getMonth() + 1)
            var year = date.getFullYear()

            return `${day}/${month}/${year}`
        },
        /**
         * Hàm sửa thông tin nhân viên
         * CreatedBy: TLKhanh(19/2/2021)
         */
        async btnUpdateClick() {
            var rowSelected = document.querySelector('.row-selected')

            if (!rowSelected) {
                alert('Vui lòng chọn nhân viên để sửa!')
                return
            }

            var employeeId = rowSelected.getAttribute('data-id')
            try {
                var response = await axios.get(
                    `http://localhost:52690/api/v1/Employees/${employeeId}`
                )
                var employee = response.data
                for (var key in employee) {
                    if (
                        key.toLowerCase().indexOf('date') !== -1 &&
                        employee[key] != null
                    ) {
                        employee[key] = employee[key].slice(0, 10)
                    }
                }
                this.employee = employee
            } catch (error) {
                console.log(error)
            }
            this.isHideParent = false
            this.focusInput()
        },
        /**
         * update lại danh sách khi xóa
         */
        onEmployeeDelete(employeeId) {
            this.$toast('Xóa nhân viên thành công!', {
                position: 'top-right',
                timeout: 2000,
                closeOnClick: true,
                pauseOnFocusLoss: true,
                pauseOnHover: true,
                draggable: true,
                draggablePercent: 0.6,
                showCloseButtonOnHover: false,
                hideProgressBar: true,
                closeButton: 'button',
                icon: true,
                rtl: false,
            })
            this.employees = this.employees.filter(
                (employee) => employee.EmployeeId != employeeId
            )
        },
        /**
         * Hàm xóa nhân viên
         * CreatedBy: TLKhanh(19/2/2021)
         */
        async btnDeleteClick() {
            var rowSelected = document.querySelector('.row-selected')
            if (!rowSelected) {
                alert('Vui lòng chọn nhân viên để xóa!')
                return
            }
            var employeeId = rowSelected.getAttribute('data-id')
            var employeeCode = rowSelected.getAttribute('data-code')
            try {
                this.isHideDialogConfirm = false
                this.employeeId = employeeId
                this.message = `Bạn có chắc chắn muốn xóa Nhân viên <<${employeeCode}>> không?`
                this.focusButton()
            } catch (error) {
                console.log(error)
            }
        },
    },
    //Hàm gọi api lấy dữ liệu
    async mounted() {
        /**
         * Gọi api lấy dữ liệu
         */
        this.loadData()

        /**
         * Sử lý key event
         *
         */
        // ctrl 1 để mở dialog thêm nhân viên
        document.addEventListener('keydown', (e) => {
            if (e.key == '1' && e.ctrlKey) {
                e.preventDefault()
                this.btnAddClick()
            }
            /**
             * Ctr D để xóa nhân viên
             */
            if (e.key == 'd' && e.ctrlKey) {
                e.preventDefault()
                if (!this.isHideParent) return
                this.btnDeleteClick()
            }

            /**
             * ctr E để xem nhân viên
             */
            if (e.key == 'e' && e.ctrlKey) {
                e.preventDefault()
                this.btnUpdateClick()
            }
            /**
             *di chuyên row selected bằng mũi tên lên xuống
             CreatedBy: TLKhanh(21/2/2021)
             */
            if (e.keyCode == 38) {
                // Lấy ra tbody chứa cá tr
                let gridContent = this.$refs.gridContent
                // Row đang được chọn
                let rowSelected = gridContent.querySelector('.row-selected')
                // Vị trí của row được chọn
                let currentIndex = rowSelected.rowIndex
                // nếu đang ở đầu thì không làm gì cả
                if (currentIndex == 1) return
                // nếu khác vị trí đầu thì sẽ chuyển selected lên dòng đằng trước
                let prevRow = gridContent.children[currentIndex - 2]
                rowSelected.classList.remove('row-selected')
                prevRow.classList.add('row-selected')
            }
            if (e.keyCode == 40) {
                // Lấy ra tbody chứa cá tr
                let gridContent = this.$refs.gridContent
                // Row đang được chọn
                let rowSelected = gridContent.querySelector('.row-selected')
                // Vị trí của row được chọn
                let currentIndex = rowSelected.rowIndex
                // nếu đang ở cuối thì không làm gì cả
                if (currentIndex == gridContent.children.length - 1) return
                // nếu khác vị trí cuối thì sẽ chuyển selected xuống dòng đằng sau
                let nextRow = gridContent.children[currentIndex]
                rowSelected.classList.remove('row-selected')
                nextRow.classList.add('row-selected')
            }
        })
    },
}
</script>

<style>
.row-selected {
    background: #d7e9f4 !important;
}
</style>
