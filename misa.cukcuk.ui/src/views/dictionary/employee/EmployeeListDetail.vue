<template>
    <div id="frmDialogDetail" class="form-dialog" :class="{ isHide: isHide }">
        <div class="dialog-modal"></div>
        <div class="dialog">
            <div class="dialog-titlebar">
                <div class="title">Thêm nhân viên</div>
                <div
                    id="btnCloseHeader"
                    class="btn-close"
                    @click="btnCancelClick"
                >
                    x
                </div>
            </div>
            <div class="dialog-body">
                <div class="toolbar">
                    <button
                        title="Ctrl S"
                        id="btnSave"
                        class="m-btn__icon"
                        @click="saveEmployee"
                    >
                        <div class="m-icon m-icon--save"></div>
                        <span>Cất</span>
                    </button>
                    <button class="m-btn__icon isDisabled">
                        <div class="m-icon m-icon--duplicate"></div>
                        <span>Nhân bản</span>
                    </button>
                    <button class="m-btn__icon isDisabled">
                        <div class="m-icon m-icon--view"></div>
                        <span>Xem</span>
                    </button>
                    <button class="m-btn__icon isDisabled">
                        <div class="m-icon m-icon--update"></div>
                        <span>Sửa</span>
                    </button>
                    <button
                        title="Ctrl D"
                        class="m-btn__icon"
                        @click="deleteEmployee"
                    >
                        <div class="m-icon m-icon--delete"></div>
                        <span>Xóa</span>
                    </button>
                    <button class="m-btn__icon isDisabled">
                        <div class="m-icon m-icon--inner"></div>
                        <span>Nạp</span>
                    </button>
                    <button class="m-btn__icon isDisabled">
                        <div class="m-icon m-icon--help"></div>
                        <span>Giúp</span>
                    </button>
                    <button
                        title="Ctr Q"
                        class="m-btn__icon"
                        @click="btnCancelClick"
                    >
                        <div class="m-icon m-icon--close"></div>
                        <span>Đóng</span>
                    </button>
                </div>
                <div class="title-group">Thông tin chung</div>
                <div class="group-general-info">
                    <div class="group-left">
                        <div class="row">
                            <label
                                >Mã nhân viên
                                <span class="label-required">(*)</span></label
                            >
                            <input
                                ref="employeeCode"
                                id="txtEmployeeCode"
                                type="text"
                                class="input-default input--short"
                                v-model="employee.EmployeeCode"
                            />
                        </div>

                        <div class="row">
                            <label title="Email"
                                >Email
                                <span class="label-required">(*)</span></label
                            >
                            <input
                                id="txtEmail"
                                type="email"
                                class="input-default input--middle"
                                v-model="employee.Email"
                            />
                        </div>

                        <div class="row">
                            <label title="Số điện thoại di động"
                                >Số điện thoại
                                <span class="label-required">(*)</span></label
                            >
                            <input
                                @keydown="onlyNumber($event)"
                                id="txtPhoneNumber"
                                type="text"
                                class="input-default input--middle"
                                v-model="employee.PhoneNumber"
                            />
                        </div>

                        <div class="row">
                            <label
                                >Họ và tên
                                <span class="label-required">(*)</span></label
                            >
                            <input
                                id="txtFullName"
                                type="text"
                                class="input-default"
                                v-model="employee.FullName"
                            />
                        </div>

                        <div class="row">
                            <div class="flex-container">
                                <label class="label-col-2">Giới tính</label>
                                <select
                                    class="option-flex-auto input-default item-1"
                                    v-model="employee.Gender"
                                >
                                    <option value="0">Nam</option>
                                    <option value="1">Nữ</option>
                                    <option value="2">khác</option>
                                </select>
                            </div>

                            <div class="flex-container">
                                <label class="ml-12px">Ngày sinh</label>
                                <input
                                    id="dtBirthday"
                                    type="date"
                                    class="input-default item-2"
                                    v-model="employee.DateOfBirth"
                                />
                            </div>
                        </div>

                        <div class="row">
                            <div class="flex-container">
                                <label
                                    title="Số chứng minh thư nhân dân hoặc sổ hộ chiếu"
                                    >Số CMT/HC<span class="label-required"
                                        >(*)</span
                                    ></label
                                >
                                <input
                                    @keydown="onlyNumber($event)"
                                    id="txtIdentityNumber"
                                    type="tel"
                                    class="input-default item-1"
                                    v-model="employee.IdentityNumber"
                                />
                            </div>
                            <div class="flex-container">
                                <label class="ml-12px">Ngày cấp</label>
                                <input
                                    id="dtBirthday"
                                    type="date"
                                    class="input-default item-2"
                                    v-model="employee.IdentityDate"
                                />
                            </div>
                        </div>
                        <div class="row">
                            <label>Nơi cấp CMND</label>
                            <input
                                id="dtBirthday"
                                type="text"
                                class="input-default"
                                v-model="employee.IdentityPlace"
                            />
                        </div>
                        <div class="row">
                            <label class="display-flex">
                                Phân quyền
                                <span class="label-required">(*)</span></label
                            >
                            <div class="flex-container">
                                <div
                                    class="display-flex mr-24px"
                                    v-for="rule in rules"
                                    :key="rule.RuleId"
                                >
                                    <input
                                        @keydown.enter="focusRadio($event)"
                                        class="input-default select-rule"
                                        type="radio"
                                        name="rule"
                                        :id="rule.RuleId"
                                        :value="rule.RuleId"
                                        style="cursor: pointer;"
                                        v-model="employee.RuleId"
                                    />
                                    <label
                                        :for="rule.RuleId"
                                        class="flex-1"
                                        style="cursor: pointer;"
                                    >
                                        {{ rule.RuleName }}</label
                                    >
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <label
                                >Trạng thái làm việc
                                <span class="label-required">(*)</span></label
                            >
                            <select
                                class="option-flex-auto input-default item-1"
                                style="cursor: pointer;"
                                v-model="employee.WorkStatusId"
                            >
                                <option
                                    v-for="workStatus in workStatuses"
                                    :key="workStatus.WorkStatusId"
                                    :value="workStatus.WorkStatusId"
                                    >{{ workStatus.WorkStatusName }}</option
                                >
                            </select>
                        </div>
                    </div>
                    <div class="group-right">
                        <div class="avatar-box">
                            <button
                                class="ct-btn ct-btn-avatar btn-select-avatar"
                            >
                                ...
                            </button>
                            <button
                                class="ct-btn ct-btn-avatar btn-remove-avatar"
                                disabled
                            >
                                <span style="width: 16px; height: 16px;"
                                    >x</span
                                >
                            </button>
                        </div>
                        <div class="tip-upload">
                            Chỉ được upload tệp <br /><b
                                >.jpg .jpeg, .png, .gif</b
                            >
                        </div>
                        <div class="box-select-avatar">
                            <input type="file" hidden="hidden" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <DialogAlert
            ref="dialogAlert"
            :isHide="isHideDialogAlert"
            :text="text"
            @closeDialog="isHideDialogAlert = $event"
            @focusInput="focusInput()"
        />
        <DialogConfirm
            ref="dialogConfirm"
            :employeeId="employeeId"
            :isHide="isHideDialogConfirm"
            :message="message"
            @closeDialogConfirm="isHideDialogConfirm = $event"
            @onEmployeeDelete="onEmployeeDelete"
            @closeDialog="closeDialog"
        />
    </div>
</template>

<script>
// import validator from 'validator'
import axios from 'axios'
import DialogAlert from '@/components/dialogs/DialogAlert'
import DialogConfirm from '@/components/dialogs/DialogConfirm'

export default {
    name: 'EmployeeListDetail',
    components: {
        DialogAlert,
        DialogConfirm,
    },
    props: {
        isHide: {
            type: Boolean,
            default: true,
        },
        newCode: {
            type: String,
        },
        data: {
            type: Object,
            default: () => {},
        },
    },
    methods: {
        /**
         * chỉ cho nhập ký tự số
         */
        onlyNumber(event) {
            var keyCode = event.keyCode
            if (
                !(
                    (keyCode >= 48 && keyCode <= 57) ||
                    keyCode == 8 ||
                    keyCode == 9 ||
                    keyCode == 37 ||
                    keyCode == 39 ||
                    keyCode == 46 ||
                    (keyCode >= 96 && keyCode <= 105)
                )
            ) {
                event.preventDefault()
                return
            }
        },
        /**
         * focus ô mã nhân viên khi thông tin gửi đi không hợp lệ
         * createdBy: TLKhanh(22/2/2021)
         */
        focusInput() {
            this.$refs.employeeCode.focus()
        },
        /**
         * Hàm focus radio button khi nhấn enter
         * createdBy: TLKhanh(21/2/2021)
         */
        focusRadio(event) {
            event.target.checked = true
            this.employee.RuleId = event.target.value
        },
        /**
         * Hàm focus button đầu tiên của Dialog
         * CreatedBy: TLKhanh(19/2/2021)
         */
        focusButton() {
            setTimeout(() => {
                this.$refs.dialogConfirm.$refs.firstButton.focus()
                this.$refs.dialogAlert.$refs.firstButton.focus()
            }, 0)
        },
        /**
         * Load lại data khi xoa
         * CreatedBy: TLKhanh(19/2/2021)
         */

        onEmployeeDelete(employeeId) {
            this.$emit('onEmployeeDelete', employeeId)
        },
        /**
         * remove validate
         * CreatedBy: TLKhanh(19/2/2021)
         */
        removeValidate() {
            var inputs = document.querySelectorAll('.input-default')

            for (var i in inputs) {
                if (inputs[i].classList) {
                    inputs[i].classList.remove('notValid')
                }
            }
        },
        /**
         * Đóng dialog
         * CreatedBy: TLKhanh(19/2/2021)
         */
        btnCancelClick() {
            this.$emit('closeDialog', true)
            this.removeValidate()
        },
        /**
         * Hàm xóa nhân viên
         * CreatedBy: TLKhanh(19/2/2021)
         * CreatedBy: TLKhanh(19/2/2021)
         */
        async deleteEmployee() {
            var employeeId = this.employee.EmployeeId
            if (!employeeId) return
            var employeeCode = this.employee.EmployeeCode
            try {
                this.isHideDialogConfirm = false
                this.employeeId = employeeId
                this.message = `Bạn có chắc chắn muốn xóa Nhân viên <<${employeeCode}>> không?`
                this.focusButton()
            } catch (error) {
                console.log(error)
            }
        },
        /**
         * Hàm thêm mới nhân viên m
         * CreatedBy: TLKhanh(19/2/2021)
         * ModifiedBy: TLKhanh(20/2/2021)
         */
        async saveEmployee() {
            /**
             * Xử lý validate dữ liệu khi cất
             * i là các trương cần validate
             * 0: mã nhân viên, 1 email, 2 số điện thoại, 3 họ tên, 6 số cmt, 9 trạng thái làm việc
             */

            var inputs = document.querySelectorAll('.input-default')
            for (var i in inputs) {
                if (i == 0 || i == 1 || i == 2 || i == 3 || i == 6 || i == 9) {
                    if (inputs[i].value.trim() == '') {
                        inputs[i].classList.add('notValid')
                    }
                }
            }
            /**
             * Hàm cất dữ liệu khi thêm mới và khi cập nhật
             * CreatedBy: TLKhanh(19/2/2021)
             * ModifiedBy: TLKhanh(20/2/2021)
             */
            var employeeId = this.employee.EmployeeId
            // Nếu không có id thì thêm mới
            if (!employeeId) {
                var employeeCodeValue = document.getElementById(
                    'txtEmployeeCode'
                ).value
                this.employee['EmployeeCode'] = employeeCodeValue
                try {
                    await axios.post(
                        'http://localhost:52690/api/v1/Employees',
                        this.employee
                    )
                    this.$emit('closeDialog', true)
                    this.$emit('loadNewEmployee')
                    //thông báo toat
                    this.$toast('Thêm nhân viên thành công!', {
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
                    // load lại dữ liệu khi thêm mới xong
                    this.$emit('loadData')
                } catch (error) {
                    this.text = error.response.data.UserMsg
                    this.isHideDialogAlert = false
                    this.focusButton()
                }
                // Nếu có id thì thực hiện cập nhật
            } else {
                try {
                    await axios.put(
                        `http://localhost:52690/api/v1/Employees/${employeeId}`,
                        this.employee
                    )
                    //thông báo toat
                    this.$toast('Cập nhật thông tin nhân viên thành công!', {
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
                    // load lại dữ liệu

                    this.$emit('loadData')
                } catch (error) {
                    this.text = error.response.data.UserMsg
                    this.isHideDialogAlert = false
                    this.focusButton()
                }
            }
        },
        /**
         * Đóng dialog
         * CreatedBy: TLKhanh(19/2/2021)
         */
        closeDialog(value) {
            this.$emit('closeDialog', value)
        },
    },
    data() {
        return {
            workStatuses: [],
            message: '',
            employeeId: '',
            rules: [],
            isHideDialogAlert: true,
            isHideDialogConfirm: true,
            text: [],
        }
    },
    async mounted() {
        /**
         * Load dữ liệu trạng thái làm vệc trong combobox
         * CreatedBy: TLKhanh(19/2/2021)
         */
        var workStatuses = await axios.get(
            'http://localhost:52690/api/v1/workstatuss'
        )
        this.workStatuses = workStatuses.data
        var rules = await axios.get('http://localhost:52690/api/v1/rules')
        this.rules = rules.data

        /**
         * Sử lý validate dữ liệu khi blur input
         * i là các trương cần validate
         * 0: mã nhân viên, 1 email, 2 số điện thoại, 3 họ tên, 6 số cmt, 9 trạng thái làm việc
         * CreatedBy: TLKhanh(19/2/2021)
         */

        var inputs = document.querySelectorAll('.input-default')

        for (var i in inputs) {
            if (i == 0 || i == 1 || i == 2 || i == 3 || i == 6 || i == 9) {
                inputs[i].onblur = function(e) {
                    if (e.target.value.trim() == '') {
                        e.target.classList.add('notValid')
                    } else {
                        e.target.classList.remove('notValid')
                    }
                }
            }
        }

        /**
         * Xử lý key equivalent
         * CreatedBy: TLKhanh(19/2/2021)
         */
        document.addEventListener('keydown', (e) => {
            /**
             * Ctrl Q để thoát dialog
             */
            if (e.key == 'q' && e.ctrlKey) {
                e.preventDefault()
                this.$emit('closeDialog', true)
                this.removeValidate()
            }
            /**
             * Ctrl S để lưu
             */
            if (e.key == 's' && e.ctrlKey) {
                e.preventDefault()
                if (this.isHide) return
                this.saveEmployee()
            }
            /**
             * Ctrl D để xóa và đóng dialog
             */
            if (e.key == 'd' && e.ctrlKey) {
                e.preventDefault()
                if (!this.isHide) {
                    this.deleteEmployee()
                } else {
                    return
                }
            }
        })
    },
    computed: {
        employee() {
            return this.data
        },
    },
}
</script>

<style scoped>
.isHide {
    display: none;
}
</style>
