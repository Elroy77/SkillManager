<template>
    <div class="row">  
        <div class="loading" v-if="loadingPage">loading..</div>
        <!-- Modal add -->
        <div class="modal fade" id="add" tabindex="-1" role="dialog" aria-labelledby="add" aria-hidden="true" >
        <div class="modal-dialog" role="document">
            <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="add">Add new employee</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
                </button>
            </div>
                <div class="modal-body">
                    <form method="post">

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
                        <label for="exampleInputEmail1" style="margin-right:380px">Add Skill</label>
                        <table>
                        <div class="form-group" style="margin-left:30px">
                            <div class="row">
                                <div class="col-md-4" style="margin-top:6px">
                                    <label for="exampleInputEmail1">Skill name</label>
                                    <select class="form-control" name="select" id="select" v-model="skillEmployeePost.skillID">
                                        <option value="0">-- Select --</option>
                                        <option v-for="(skill,index) in listSkill" :key="index" :value="skill.id" >{{skill.name}}</option>
                                    </select>
                                </div>
                                <div class="col-md-4">
                                    <label for="recipient-name" class="col-form-label">Experience</label>
                                    <select v-model="skillEmployeePost.experience" class="form-control">
                                        <option value="0">-- Select --</option>
                                        <option v-for="(option,index) in listexp" v-bind:value="option.value" v-bind:key="index">
                                            {{ option.text }}
                                        </option>
                                    </select>
                                </div> 
                                <div class="col-md-4" style="margin-top:37px">
                                    <button type="button" class="btn btn-info" id="btnAdd" name="btnAdd" v-on:click="addSkill()">Add</button>
                                </div>
                            </div>   
                        </div>
                        </table>
                        <table style="margin-left:10px">

                            <tr v-for="(skill, index) in employeePost.detailSkill" :key="index">
                                <td>
                                    <input class="inputSkill" type="number" v-model="skill.skillID" disabled>
                                    <input class="inputSkill" type="number" v-model="skill.experience" disabled>
                                    <button type="button" class="btn btn-danger" v-on:click="removeSkill(skill)">X</button>
                                </td>                                
                            </tr>
                        </table> 
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
            <base-input ref="EmployeefullNameUpdate">{{part.fullName}}</base-input>
            <base-input ref="EmployeegenderUpdate">{{part.gender}}</base-input>
            <base-input ref="EmployeejobPositionUpdate">{{part.jobPosition}}</base-input>
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
                        <select class="form-control" name="select" id="select" v-model="listEmployee.skillname">
                            <option value="0">-- Select --</option>
                            <option v-for="(skill,index) in listSkill" :key="index">{{skill.name}}</option>
                        </select>
                        &nbsp;&nbsp;
                        <button class="btn btn-outline-success my-2 my-sm-0" v-on:click="searchEmployee(listEmployee.fullName,listEmployee.skillname)">Search</button>
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
        <nav aria-label="Page navigation example">
        <ul class="pagination justify-content-end">
            <li class="page-item"><a class="page-link" href="#" tabindex="-1">◀</a></li>
            <li class="page-item"><button class="page-link" v-on:click="getEmployeePaging(1)">1</button></li>
            <li class="page-item"><button class="page-link" v-on:click="getEmployeePaging(2)">2</button></li>
            <li class="page-item"><button class="page-link" v-on:click="getEmployeePaging(3)">3</button></li>
            <li class="page-item"><button class="page-link" v-on:click="getEmployeePaging(4)">4</button></li>
            <li class="page-item"><a class="page-link" href="#">▶</a></li>
        </ul>
        </nav>
    </div>                       
</template>

<script>
// import Paginate from 'vuejs-paginate'
// Vue.component('paginate', Paginate)
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
                perPage: 3,
                currentPage: 1,
                listEmployee: {
                    skillname:"0"
                },
               loadingPage:false,
                listSkill:{},
                part: {},
                employeePost: {
                    fullName:'',
                    gender:3,
                    jobPosition:5,
                    detailSkill: [
                        {  
                            skillID:1,
                            experience:11
                        }                    
                    ]                 
                },
                skillEmployeePost:{
                    skillID:0,
                    experience:0
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
                ],
                listexp: [
                    { text: '1 month', value: 1 },
                    { text: '2 month', value: 2 },
                    { text: '3 month', value: 3 },
                    { text: '4 month', value: 4 },
                    { text: '5 month', value: 5 },
                    { text: '6 month', value: 6 },
                    { text: '7 month', value: 7 },
                    { text: '8 month', value: 8 },
                    { text: '9 month', value: 9 },
                    { text: '10 month', value: 10 },
                    { text: '11 month', value: 11 },
                    { text: '12 month', value: 12 },
                    { text: '13 month', value: 13 },
                    { text: '14 month', value: 14 },
                    { text: '15 month', value: 15 },
                    { text: '16 month', value: 16 },
                    { text: '17 month', value: 17 },
                    { text: '18 month', value: 18 },
                    { text: '19 month', value: 19 },
                    { text: '20 month', value: 20 },
                    { text: '21 month', value: 21 },
                    { text: '22 month', value: 22 },
                    { text: '23 month', value: 23 },
                    { text: '24 month', value: 24 },
                    { text: '25 month', value: 25 },
                    { text: '26 month', value: 26 },
                    { text: '27 month', value: 27 },
                    { text: '28 month', value: 28 },

                ]
            }
        },
        methods:{
            getEmployee()
            {
                this.loadingPage = true
                    setTimeout(() => {this.loadingPage = false},1500)
                    {
                        EmployeeService.getAllEmpl()
                            .then((resp) => {
                                this.listEmployee = resp.data.data
                                console.warn(resp.data.data)
                            })
                    }            
            },
            getEmployeePaging(page)
            {
                EmployeeService.getlistEmplpaging(page)
                    .then((resp) => {
                        this.listEmployee = resp.data.data
                        console.warn(resp.data.data)
                    })  
            },
            searchEmployee(fullname, skillname) {
                EmployeeService.getlistEmplNS(fullname,skillname)
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
            addSkill() {
                this.employeePost.detailSkill.push(
                    {skillID:this.skillEmployeePost.skillID,
                experience:this.skillEmployeePost.experience}
                )                
                console.log(this.skillEmployeePost)
                this.$toasted.show('Add skill success!').goAway(1500)
                       this.skillEmployeePost.skillID = 0,
                       this.skillEmployeePost.experience = 0        

            },
            removeSkill(skill) {
                this.employeePost.detailSkill.splice(skill,1)
                this.$toasted.show('delete skill employee success!').goAway(1500)                

            } 
        },
        mounted() {  
            this.getEmployee()    
            this.getSkill() 
        }
    }
</script>
<style scoped src="@/assets/css/style.css">

</style>