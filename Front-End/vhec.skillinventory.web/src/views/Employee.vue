<template>
<div class="row">   
        <!-- Modal add -->
        <div class="modal fade" id="add" tabindex="-1" role="dialog" aria-labelledby="add" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="add">Add new employee</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
                </button>
            </div>
                <div class="modal-body">
                    <form @submit.prevent="postEmployee">

                        <div class="form-group">
                            <label for="recipient-name" class="col-form-label" style="margin-right:370px">Full name</label>
                            <input type="text" class="form-control" id="recipient-name" v-model="employeePost.fullName" placeholder="Enter name...">
                        </div>                   
                        <div class="form-group" style="margin-right:360px">
                            <label for="exampleInputEmail1" style="margin-right:30px">Gender</label>
                            <select v-model="employeePost.gender" class="form-control">
                                <option value="3">-- Select --</option>
                            <option v-for="(option,index) in optionGenders" v-bind:value="option.value" v-bind:key="index">
                                {{ option.text }}
                            </option>
                            </select>
                        </div>
                        
                        <div class="form-group" style="margin-right:360px">
                            <label for="exampleInputEmail1" style="margin-right:30px">Position</label>
                            <select v-model="employeePost.jobPosition" class="form-control">
                                <option value="5">-- Select --</option>
                                <option v-for="(option,index) in optionPositions" v-bind:value="option.value" v-bind:key="index" >
                                    {{ option.text }}
                                </option>
                            </select>
                        </div>
                        <table>
                            <tr v-for="(skill, index) in employeePost.detailSkills" :key="index">
                                <td>
                                    <input type="text" v-model="skill.skillID">
                                </td>
                                <td>
                                    <input type="text" v-model="skill.experience">
                                </td>
                                <td>
                                    <button>add </button>
                                    <button>delete </button>
                                </td>
                            </tr>
                        </table>
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#addskill" data-dismiss="modal" >Add new</button>
 
                        <div class="modal-footer">
                            <button type="button"  class="btn btn-secondary" data-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-primary" id="btnAdd" name="btnAdd" v-on:click="postEmployee()" data-dismiss="modal" >Create</button>
                        </div>
                    </form>
                </div> 
            </div>
        </div>
        </div>
        <!-- End Modal add -->
        <!-- Modal add skill-->
        <div class="modal fade" id="addskill" tabindex="-1" role="dialog" aria-labelledby="addskill" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="addskill">Add skill employee</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
                </button>
            </div>
                <div class="modal-body">
                    <form @submit.prevent="postEmployee">
                        <div>
                            <label for="tags-basic" style="margin-right:380px">Add Skill</label>
                            <b-form-tags input-id="tags-basic" v-model="skill"></b-form-tags>
                        </div>
                         <div class="form-group" style="margin-right:370px">
                            <label for="recipient-name" class="col-form-label" style="margin-right:0px">Experience</label>
                            <input type="text" class="form-control" id="recipient-name" placeholder="Number...">
                        </div>     
                        <div class="modal-footer">
                            <button type="button"  class="btn btn-secondary" data-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-primary" id="btnAdd" name="btnAdd" v-on:click="employeePost()" data-dismiss="modal" >Create</button>
                        </div>
                    </form>
                </div> 
            </div>
        </div>
        </div>
        <!-- End Modal add skill -->

        <!-- Modal update -->
        <div class="modal fade" id="update" tabindex="-1" role="dialog" aria-labelledby="update" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="update">Update employee</h5>                
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <br>
            <h5 id="EmployeeIdUpdate">ID: <base-input ref="EmployeeIdUpdate">{{part.id}}</base-input></h5>
            <!-- <base-input ref="EmployeefullNameUpdate">{{part.fullName}}</base-input>
            <base-input ref="EmployeegenderUpdate">{{part.gender}}</base-input>
            <base-input ref="EmployeejobPositionUpdate">{{part.jobPosition}}</base-input> -->
                <div class="modal-body">
                    <form @submit.prevent="putEmployee" method="post">
                        <div class="form-group">
                            <label for="recipient-name" class="col-form-label" style="margin-right:370px">Full name</label>
                            <input type="text" class="form-control" id="recipient-name" v-model="employeePut.fullName" placeholder="Enter name...">
                        </div>                   
                        <div class="form-group" style="margin-right:360px">
                            <label for="exampleInputEmail1" style="margin-right:30px">Gender</label>
                            <select v-model="employeePut.gender" class="form-control">
                                <option value="3">-- Select --</option>
                            <option v-for="(option,index) in optionGenders" v-bind:value="option.value" v-bind:key="index">
                                {{ option.text }}
                            </option>
                            </select>
                        </div>
                       
                        <div class="form-group" style="margin-right:360px">
                            <label for="exampleInputEmail1" style="margin-right:30px">Position</label>
                            <select v-model="employeePut.jobPosition" class="form-control">
                                <option value="5">-- Select --</option>
                                <option v-for="(option,index) in optionPositions" v-bind:value="option.value" v-bind:key="index" >
                                    {{ option.text }}
                                </option>
                            </select>
                        </div>
                        <div>
                            <label for="tags-basic">Update Skill</label>
                            <b-form-tags input-id="tags-basic" v-model="skill"></b-form-tags>
                        </div>
                        <div class="modal-footer">
                            <button type="button"  class="btn btn-secondary" data-dismiss="modal">Close</button>
                            <button type="submit" class="btn btn-primary" v-on:click="putEmployee()" data-dismiss="modal">Update</button>
                        </div>
                    </form>
                </div> 
            </div>
        </div>
        </div>
        <!-- End Modal update -->

        <!-- Modal deatil -->
        <div class="modal fade" id="detail" tabindex="-1" role="dialog" aria-labelledby="detail" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="detail">detail employee</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
                </button>
            </div>
                <div class="modal-body">
                    <ul class="list-group">
                        <li class="list-group-item block-email" style="color:red">Id: {{part.id}}</li>
                        <li class="list-group-item" style="color:#0000FF" >full Name: {{part.fullName}}</li>
                        <li class="list-group-item status--male" v-if="part.gender == 0">Gender: Male</li>
                        <li class="list-group-item status--female" v-else-if="part.gender == 1" >Gender: Female</li>
                        <li class="list-group-item status--other" v-else-if="part.gender == 2">Gender: Ohter</li>
                        <li class="list-group-item " v-if="part.jobPosition == 0">Job position: Manager</li>
                        <li class="list-group-item " v-else-if="part.jobPosition == 1">Job position: Developer</li>
                        <li class="list-group-item " v-else-if="part.jobPosition == 2">Job position: Tester</li>
                        <li class="list-group-item " v-else-if="part.jobPosition == 3">Job position: Designer</li>
                        <li class="list-group-item " v-else-if="part.jobPosition == 4">Job position: Analytical</li>
                        <li class="list-group-item">Skill:</li>
                        <li class="list-group-item">Day Created: {{moment(part.dayCreated).format('YYYY-MM-DD')}}</li>
                        <li class="list-group-item">Update at: {{part.dayCreated}}</li>
                    </ul> 
                    <div class="modal-footer">
                            <button type="button"  class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>                       
                </div> 
            </div>
        </div>
        </div>
        <!-- End Modal detail -->
        <div class="col-md-12">
            <!-- DATA TABLE -->
            <br>
            <h2 class="title-5 m-b-35">Employee manager</h2><br>
            <div class="table-data__tool">
                <div class="table-data__tool-left">
                    <form class="form-inline" @submit.prevent="listEmployee">
                        <input class="form-control mr-sm-2" type="search" placeholder="Enter name..." aria-label="Search" v-model="listEmployee.fullName">
                        <select class="form-control" name="select" id="select">
                            <option>-- Select --</option>
                            <option v-for="(skill,index) in listSkill" :key="index">{{skill.name}}</option>
                        </select>
                        &nbsp;&nbsp;
                        <button class="btn btn-outline-success my-2 my-sm-0" v-on:click="searchEmployee(listEmployee.fullName)">Search</button>
                    </form>
                </div>
                <div class="table-data__tool-right" style="margin-right:50px">
                    <button class="au-btn au-btn-icon au-btn--green au-btn--small" data-toggle="modal" data-target="#add">
                        <i class="zmdi zmdi-plus"></i>＋add new</button>
                    <div class="rs-select2--dark rs-select2--sm rs-select2--dark2">
                    </div>
                </div>
            </div>
            <div class="table-responsive table-responsive-data2">
                <table class="table table-data2">
                    <thead>
                        <tr>
                            <th scope="col">Full name</th>
                            <th scope="col">Gender</th>
                            <th scope="col">Position</th>
                            <th scope="col">Updated At</th>
                            <th scope="col">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="tr-shadow" v-for="(item,index) in listEmployee" :key="index">      
                            <td>
                                <span class="block-email">{{item.fullName}}</span>
                            </td>
                            <td>
                                <span class="status--male" v-if="item.gender == 0">Male</span>
                                <span class="status--female" v-else-if="item.gender == 1">Female</span>
                                <span class="status--other" v-else-if="item.gender == 2">Other</span>
                            </td>
                             <td>
                                <span class="role manager" v-if="item.jobPosition == 0">Manager</span>
                                <span class="role developer" v-else-if="item.jobPosition == 1">Developer</span>
                                <span class="role tester" v-else-if="item.jobPosition == 2">Tester</span>
                                <span class="role designer" v-else-if="item.jobPosition == 3">Designer</span>
                                <span class="role analytical" v-else-if="item.jobPosition == 4">Analytical</span>
                            </td>
                            <td>
                                {{moment(item.dayCreated).format('YYYY-MM-DD')}}
                            </td>
                            <td>
                                <div class="table-data-feature">
                                    <button class="item" data-placement="top" title="detail" data-toggle="modal" data-target="#detail">
                                        <i class="material-icons" v-on:click="getEmployeeId(item.id)">İ</i>
                                    </button>
                                    <button class="item" data-placement="top" title="Edit" data-toggle="modal" data-target="#update" >
                                        <i class="zmdi zmdi-edit" v-on:click="getEmployeeId(item.id)">✎</i>
                                    </button>
                                    <button class="item" data-toggle="tooltip" data-placement="top" title="Delete">
                                        <i class="zmdi zmdi-delete" v-on:click="deleteEmployee(item.id)">☒</i>
                                    </button>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <!-- END DATA TABLE -->
        </div>
    </div>                       
</template>

<script>
    import Vue from 'vue';
    import axios from 'axios'
    import VueAxios from 'vue-axios'
    import EmployeeService from '@/APIServices/EmployeeService';
    import SkillService from '@/APIServices/SkillService'

    Vue.use(VueAxios, axios)
    export default {
        name: "Employee",
        data() {
            return { 
                listEmployee: {},
                listSkill:{},
                part: {},
                skill: ['C#','Html', 'Css'] ,
                employeePost: {
                    fullName:'',
                    gender:3,
                    jobPosition:5,
                    detailSkills: [
                        {
                            skillID:1,
                            experience:14
                        },
                        {
                            skillID:2,
                            experience:2
                        },
                        {
                            skillID:3,
                            experience:2
                        }
                    ]                 
                },
                employeePut: {
                    fullName: '',
                    gender:3,
                    jobPosition:5           
                },
                optionGenders: [
                { text: 'Male', value: 0 },
                { text: 'Female', value: 1 },
                { text: 'Other', value: 2 },
                                ],
                optionPositions: [
                    { text: 'Manager', value: 0 },
                    { text: 'Developer', value: 1 },
                    { text: 'Tester', value: 2 },
                    { text: 'Designer', value: 3 },
                    { text: 'Analytical', value: 4 }
                ]
            }
        },
        methods:{
            getEmployee()
            {
                EmployeeService.getAllEmpl()
                    .then((resp) => {
                        this.listEmployee = resp.data.data
                        console.warn(resp.data.data)
                    })  
            },
            searchEmployee(FullName) {
                EmployeeService.getlistEmpl(FullName)
                    .then((resp) => {
                        this.listEmployee = resp.data.data
                        console.warn(resp.data.data)
                    })  
            },
            getEmployeeId(id) {
                EmployeeService.getByIdEmpl(id)
                    .then((result) => {
                    this.part = result.data;
                    console.log(this.part);
                })
            },
            postEmployee() 
            {
                console.warn(this.employeePost)
                EmployeeService.postEmpl(this.employeePost)
                .then(() =>{
                    this.getEmployee()
                })
                .then(response => console.log(response))
                this.$toasted.show('Add new employee success!').goAway(1500)                
            },
            putEmployee()
            {
                let idEmployee = this.$refs.EmployeeIdUpdate.innerHTML
                EmployeeService.putEmpl(idEmployee, this.employeePut)
                .then(() =>{
                    this.getEmployee()
                })
                .then(response => console.log(response))
                this.$toasted.show('Update employee success!').goAway(1500)                
            },
            deleteEmployee(id)
            {
                EmployeeService.deleteEmpl(id)
                .then(() =>{
                    this.getEmployee()}
                )
                .then(response => console.log(response))
                this.$toasted.show('Delete employee success!').goAway(1500)

            },
            getSkill()
            {
                SkillService.getAllSk()
                    .then((resp) => {
                        this.listSkill = resp.data.data
                        console.warn(resp.data.data)
                    })  
            },          
        },
        mounted() {  
            this.getEmployee()    
            this.getSkill() 
        }
    }
</script>
<style scoped>
.table-data {
    height: 472px;
    overflow-y: auto;
}

.table-data thead tr td {
    font-size: 12px;
    font-weight: 600;
    color: #808080;
    text-transform: uppercase;
}

.table-data .table td {
    border-top: none;
    border-bottom: 1px solid #f2f2f2;
    padding-top: 23px;
    padding-bottom: 33px;
    padding-left: 40px;
    padding-right: 10px;
}

.table-data .table tr td:last-child {
    padding-right: 24px;
}

.table-data tbody tr:hover td .more {
    -webkit-transform: scale(1);
    -moz-transform: scale(1);
    -ms-transform: scale(1);
    -o-transform: scale(1);
    transform: scale(1);
}

.table-data__info h6 {
    font-size: 14px;
    color: #808080;
    text-transform: capitalize;
    font-weight: 400;
}

.table-data__info span a {
    font-size: 12px;
    color: #999;
}

.table-data__info span a:hover {
    color: #666;
}

.table-data__tool {
    display: -webkit-box;
    display: -webkit-flex;
    display: -moz-box;
    display: -ms-flexbox;
    display: flex;
    -webkit-box-pack: justify;
    -webkit-justify-content: space-between;
    -moz-box-pack: justify;
    -ms-flex-pack: justify;
    justify-content: space-between;
    margin-bottom: 28px;
}

.table-data__tool .table-data__tool-left > div {
    margin-right: 12px;
}

.table-data__tool .table-data__tool-right > button {
    margin-right: 12px;
}

@media (max-width: 991px) {
    .table-data__tool {
        -webkit-box-orient: vertical;
        -webkit-box-direction: normal;
        -webkit-flex-direction: column;
        -moz-box-orient: vertical;
        -moz-box-direction: normal;
        -ms-flex-direction: column;
        flex-direction: column;
    }

    .table-data__tool .table-data__tool-right {
        margin-top: 10px;
    }

    .table-data__tool .table-data__tool-right > button {
        margin-right: 0;
        margin-bottom: 10px;
    }
}

.table-data__tool .table-data__tool-left > div {
    margin-right: 12px;
}

.form-inline {
    margin-left: 60px;
}

.table-data__tool .table-data__tool-right > button {
    margin-right: 12px;
}
.table-data2 {
    border-collapse: collapse;
    overflow: visible;
}

.table-data2.table thead th {
    font-size: 12px;
    color: #555;
    text-transform: uppercase;
    border: none;
    font-weight: 600;
    vertical-align: top;
    padding: 15px 40px;
    padding-right: 10px;
}

.table-data2.table thead th:first-child {
    padding-right: 0;
}

.table-data2.table tbody {
    background: #fff;
}

.table-data2.table tbody tr td:first-child {
    -webkit-border-top-left-radius: 3px;
    -moz-border-radius-topleft: 3px;
    border-top-left-radius: 3px;
    -webkit-border-bottom-left-radius: 3px;
    -moz-border-radius-bottomleft: 3px;
    border-bottom-left-radius: 3px;
    vertical-align: top;
}

.table-data2.table tbody tr td:first-child .au-checkbox {
    margin-top: 5px;
}

@media (max-width: 1199px) {
    .table-data2.table tbody tr td:first-child {
        vertical-align: middle;
    }

    .table-data2.table tbody tr td:first-child .au-checkbox {
        margin-top: 0;
    }
}

.table-data2.table tbody tr td:last-child {
    -webkit-border-top-right-radius: 3px;
    -moz-border-radius-topright: 3px;
    border-top-right-radius: 3px;
    -webkit-border-bottom-right-radius: 3px;
    -moz-border-radius-bottomright: 3px;
    border-bottom-right-radius: 3px;
    padding-right: 35px;
}

.table-data2.table tbody td {
    font-size: 14px;
    color: #808080;
    vertical-align: middle;
    padding: 25px 40px;
    padding-right: 10px;
    border: none;
}

.table-data2.table tbody td.desc {
    color: #4272d7;
}

.table-data2 .spacer {
    height: 5px;
    background: transparent;
}

.table {
    margin: 0;
}

@media (min-width: 1200px) {
    .table-responsive-data2 {
        overflow: visible;
    }
}

.table-responsive {
    padding-right: 1px;
}

.table-responsive.table--no-card {
    -webkit-border-radius: 10px;
    -moz-border-radius: 10px;
    border-radius: 10px;
    -webkit-box-shadow: 0px 2px 5px 0px rgba(0, 0, 0, 0.1);
    -moz-box-shadow: 0px 2px 5px 0px rgba(0, 0, 0, 0.1);
    box-shadow: 0px 2px 5px 0px rgba(0, 0, 0, 0.1);
}

.tr-shadow {
    -webkit-box-shadow: 0px 10px 20px 0px rgba(0, 0, 0, 0.03);
    -moz-box-shadow: 0px 10px 20px 0px rgba(0, 0, 0, 0.03);
    box-shadow: 0px 10px 20px 0px rgba(0, 0, 0, 0.03);
}

.block-email {
    font-size: 14px;
    color: #808080;
    display: inline-block;
    background: #f2f2f2;
    -webkit-border-radius: 2px;
    -moz-border-radius: 2px;
    border-radius: 2px;
    line-height: 30px;
    padding: 0 14px;
}

.status--male {
    color: #00ad5f;
}

.status--female {
    color: #fa4251;
}

.status--other {
    color: #8b00fd;
}

.role {
    display: inline-block;
    line-height: 30px;
    font-size: 14px;
    color: #fff;
    padding: 0 15px;
    -webkit-border-radius: 3px;
    -moz-border-radius: 3px;
    border-radius: 3px;
    text-transform: capitalize;
}

.role.manager {
    background: #fa4251;
}

.role.developer {
    background: #30704b;
}

.role.tester {
    background: #4197c9;
}

.role.designer {
    background: #9b8f24;
}

.role.analytical {
    background: #396d6d;
}

.table-data-feature {
    display: -webkit-box;
    display: -webkit-flex;
    display: -moz-box;
    display: -ms-flexbox;
    display: flex;
    -webkit-box-pack: end;
    -webkit-justify-content: flex-end;
    -moz-box-pack: end;
    -ms-flex-pack: end;
    justify-content: flex-end;
}

.table-data-feature .item {
    display: block;
    height: 30px;
    width: 30px;
    position: relative;
    -webkit-border-radius: 100%;
    -moz-border-radius: 100%;
    border-radius: 100%;
    background: #e5e5e5;
    margin-right: 5px;
}

.table-data-feature .item:last-child {
    margin-right: 0;
}

.table-data-feature .item i {
    font-size: 20px;
    color: #808080;
    position: absolute;
    top: 50%;
    left: 50%;
    -webkit-transform: translate(-50%, -50%);
    -moz-transform: translate(-50%, -50%);
    -ms-transform: translate(-50%, -50%);
    -o-transform: translate(-50%, -50%);
    transform: translate(-50%, -50%);
}
.au-btn--small {
    padding: 0 20px;
    line-height: 40px;
    font-size: 14px;
}
.au-btn {
    line-height: 45px;
    padding: 0 35px;
    text-transform: uppercase;
    color: #fff;
    -webkit-border-radius: 3px;
    -moz-border-radius: 3px;
    border-radius: 3px;
    -webkit-transition: all 0.3s ease;
    -o-transition: all 0.3s ease;
    -moz-transition: all 0.3s ease;
    transition: all 0.3s ease;
    cursor: pointer;
}

.au-btn:hover {
    color: #fff;
    background: #3868cd;
}

.au-btn--blue2 {
    background: #00aced;
}

.au-btn--blue2:hover {
    background: #00a2e3;
}

.au-btn--block {
    display: block;
    width: 100%;
}

.au-btn-icon i {
    vertical-align: baseline;
    margin-right: 5px;
}

.au-btn--blue {
    background: #4272d7;
}

.au-btn--green {
    background: #63c76a;
}

.au-btn--green:hover {
    background: #59bd60;
}

.au-btn-plus {
    position: absolute;
    height: 45px;
    width: 45px;
    background: #63c76a;
    -webkit-border-radius: 100%;
    -moz-border-radius: 100%;
    border-radius: 100%;
    -webkit-transition: all 0.3s ease;
    -o-transition: all 0.3s ease;
    -moz-transition: all 0.3s ease;
    transition: all 0.3s ease;
    bottom: -22.5px;
    right: 45px;
    z-index: 3;
}

.au-btn-plus i {
    position: absolute;
    top: 50%;
    left: 50%;
    -webkit-transform: translate(-50%, -50%);
    -moz-transform: translate(-50%, -50%);
    -ms-transform: translate(-50%, -50%);
    -o-transform: translate(-50%, -50%);
    transform: translate(-50%, -50%);
    font-size: 15px;
    font-weight: 500;
    color: #fff;
}

.au-btn-plus:hover {
    background: #59bd60;
}

.au-btn-load {
    background: #808080;
    padding: 0 40px;
    font-size: 15px;
    color: #fff;
}

.au-btn-load:hover {
    background: #767676;
}

.au-btn-filter {
    font-size: 14px;
    color: #808080;
    background: #fff;
    -webkit-border-radius: 3px;
    -moz-border-radius: 3px;
    border-radius: 3px;
    -webkit-box-shadow: 0px 10px 20px 0px rgba(0, 0, 0, 0.03);
    -moz-box-shadow: 0px 10px 20px 0px rgba(0, 0, 0, 0.03);
    box-shadow: 0px 10px 20px 0px rgba(0, 0, 0, 0.03);
    padding: 0 15px;
    line-height: 40px;
    text-transform: capitalize;
}

.au-btn-filter i {
    margin-right: 5px;
}

.au-btn--small {
    padding: 0 20px;
    line-height: 40px;
    font-size: 14px;
}
</style>