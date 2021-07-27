<template>
<div class="row">   
        <div class="col-md-12">
            <!-- DATA TABLE -->
            <br>
            <h2 class="title-5 m-b-35">Skill manager</h2><br>
            <div class="table-data__tool">
                <div class="table-data__tool-left">
                    <form class="form-inline" >
                        <input class="form-control mr-sm-2" type="search" placeholder="Enter name..." aria-label="Search">
                        <select class="form-control" name="select" id="select" >
                            <option value="0">-- Select --</option>
                            <option v-for="(skill,index) in listSkill" :key="index">{{skill.name}}</option>
                        </select>
                        &nbsp;&nbsp;
                        <button class="btn btn-outline-success my-2 my-sm-0">Search</button>
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
                            <th scope="col">id</th>
                            <th scope="col">name</th>
                            <th scope="col">Update at</th>
                            <th scope="col">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="tr-shadow" v-for="(item,index) in listSkill" :key="index">      
                            <td>
                                <span>{{item.id}}</span>
                            </td>                            
                            <td>
                                <span class="block-email">{{item.name}}</span>
                            </td>
                            <td>
                                {{moment(item.dayCreated).format('YYYY-MM-DD')}}
                            </td>
                            <td>
                                <div class="table-data-feature">
                                    <button class="item" data-placement="top" title="detail" data-toggle="modal" data-target="#detail">
                                        <i class="material-icons">İ</i>
                                    </button>
                                    <button class="item" data-placement="top" title="Edit" data-toggle="modal" data-target="#update" >
                                        <i class="zmdi zmdi-edit" >✎</i>
                                    </button>
                                    <button class="item" data-toggle="tooltip" data-placement="top" title="Delete">
                                        <i class="zmdi zmdi-delete">☒</i>
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
    import SkillService from '@/APIServices/SkillService'

    Vue.use(VueAxios, axios)
    export default {
        name: "Employee",
        data() {
            return { 
                listSkill:{},
            }
        },
        methods:{
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
            this.getSkill() 
        }
    }
</script>
<style scoped src="@/assets/css/style.css">

</style>