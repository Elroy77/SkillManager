<template>
<div class="row">   
        <!-- Modal -->
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
                    <form>
                        <div class="form-group">
                            <label for="recipient-name" class="col-form-label">Full name</label>
                            <input type="text" class="form-control" id="recipient-name">
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Gender</label>
                            <select class="form-control">
                                <option>Male</option>
                                <option>Female</option>
                                <option>Other</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Position</label>
                            <select class="form-control">
                                <option>Manager</option>
                                <option>Developer</option>
                                <option>Tester</option>
                                <option>Designer</option>
                            </select>
                        </div>
                        <div>
                            <label for="tags-basic">Add Skill</label>
                            <b-form-tags input-id="tags-basic" v-model="skill"></b-form-tags>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-primary">Save changes</button>
                        </div>
                    </form>
                </div> 
            </div>
        </div>
        </div>
        <!-- End Modal -->
        <div class="col-md-12">
            <!-- DATA TABLE -->
            <br>
            <h2 class="title-5 m-b-35">Employee manager</h2><br>
            <div class="table-data__tool">
                <div class="table-data__tool-left">
                    <form class="form-inline">
                        <input class="form-control mr-sm-2" type="search" placeholder="ID..." aria-label="Search">
                        <select name="select" id="select" class="form-control">
                            <option value="0">Select skill</option>
                            <option value="1">Option #1</option>
                        </select>
                        &nbsp;&nbsp;
                        <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
                    </form>
                </div>
                <div class="table-data__tool-right">
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
                           <th scope="col">ID</th>
                            <th scope="col">Full name</th>
                            <th scope="col">Gender</th>
                            <th scope="col">Position</th>
                            <th scope="col">created</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="tr-shadow" v-for="item in list" :key="item.employeeId">      
                            <td>{{item.employeeId}}</td>
                            <td>
                                <span class="block-email">{{item.fullName}}</span>
                            </td>
                            <td>
                                <span class="status--process" v-if="item.gender == 0">Male</span>
                                <span class="status--denied" v-else>Female</span>
                            </td>
                             <td>
                                <span class="role manager" v-if="item.jobPosition == 0">Manager</span>
                                <span class="role developer" v-else-if="item.jobPosition == 1">Developer</span>
                                <span class="role tester" v-else-if="item.jobPosition == 2">Tester</span>
                                <span class="role designer" v-else-if="item.jobPosition == 3">Designer</span>
                                <span class="role analytical" v-else-if="item.jobPosition == 4">Analytical</span>
                            </td>
                            <td>{{item.dayCreated}}</td>
                            <td>
                                <div class="table-data-feature">
                                    <button class="item" data-toggle="tooltip" data-placement="top" title="detail">
                                        <i class="material-icons">İ</i>
                                    </button>
                                    <button class="item" data-toggle="tooltip" data-placement="top" title="Edit">
                                        <i class="zmdi zmdi-edit">✎</i>
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
    Vue.use(VueAxios, axios)
    export default {
        name: "Employee",
        data() {
            return { 
                list: undefined,
                skill: ['C#', 'SqlServer'] 
                }
        },
        mounted() {
            Vue.axios.get('http://localhost:5000/api/employee/list')
                .then((resp) => {
                    this.list = resp.data.data
                    console.warn(resp.data.data)
                })
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

.status--process {
    color: #00ad5f;
}

.status--denied {
    color: #fa4251;
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
    background: #310b22;
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