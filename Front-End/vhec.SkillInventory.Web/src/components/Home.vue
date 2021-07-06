<template>
    <div>
        <center>
            <center>
                <h1 class="mt-5">Employee manager</h1>
            </center>
            <button type="button" class="create" id="create">
                <i class="fas fa-plus">Create</i>
            </button>
            <table class="styled-table" id="">
                <thead>
                    <tr>
                        <th scope="col">ID</th>
                        <th scope="col">Full name</th>
                        <th scope="col">Gender</th>
                        <th scope="col">Job position</th>
                        <th scope="col">created</th>&nbsp;
                        <th scope="col">Action</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="item in list" :key="item.employeeId">
                        <th scope="row">{{item.employeeId}}</th>
                        <td>{{item.fullName}}</td>
                        <td>{{item.gender}}</td>
                        <td>{{item.jobPosition}}</td>
                        <td>{{item.dayCreated}}</td>
                        &nbsp;
                        <!--<td><i class="btn btn-danger btn-sm px-3" style="font-style: initial;">High</i></td>
    <td><i class="btn btn-dark btn-sm px-3" style="font-style: initial;">Open</i></td>-->
                        <td>
                            <button type="button" class="detail" id="detail">
                                <i class="fas fa-file">detail</i>
                            </button>&nbsp;
                            <button type="button" class="edit" id="edit">
                                <i class="fas fa-pen">Edit</i>
                            </button>&nbsp;
                            <button type="button" class="delete" id="delete">
                                <i class="fas fa-times">Update</i>
                            </button>&nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
        </center>
    </div>
</template>
<script>
    import Vue from 'vue';
    import axios from 'axios'
    import VueAxios from 'vue-axios'
    Vue.use(VueAxios, axios)
    export default {
        name: "Home",
        data() {
            return { list: undefined }
        },
        mounted() {
            Vue.axios.get('http://localhost:5000/api/employee/list') // //
                .then((resp) => {
                    this.list = resp.data.data
                    console.warn(resp.data.data)
                })
        }
    }
</script>

<style>
    .styled-table {
        border-collapse: collapse;
        margin: 25px 0;
        font-size: 0.9em;
        font-family: sans-serif;
        min-width: 400px;
        box-shadow: 0 0 20px rgba(0, 0, 0, 0.15);
    }
        .styled-table thead tr {
            background-color: #009879;
            color: #ffffff;
            text-align: left;
        }
        .styled-table th,
        .styled-table td {
            padding: 12px 15px;
        }
        .styled-table tbody tr {
            border-bottom: 1px solid #dddddd;
        }

            .styled-table tbody tr:nth-of-type(even) {
                background-color: #f3f3f3;
            }

            .styled-table tbody tr:last-of-type {
                border-bottom: 2px solid #009879;
            }
            .styled-table tbody tr.active-row {
                font-weight: bold;
                color: #009879;
            }
    .create {
        background-color: #4CAF50; /* Green */
        border: none;
        color: white;
        padding: 15px 32px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 16px;
    }
    .delete {
        background-color: #f44336; /* red */
        border: none;
        color: white;
        padding: 15px 32px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 16px;
    }
    .detail {
        background-color: #008CBA; /* blue */
        border: none;
        color: white;
        padding: 15px 32px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 16px;
    }
    .edit {
        background-color: gold; /* gold */
        border: none;
        color: white;
        padding: 15px 32px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 16px;
    }

</style>