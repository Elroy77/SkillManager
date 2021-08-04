<template>
    <div>
    <div class="row">
      <div class="col-12">
         <nav class="navbar navbar-expand-sm bg-dark navbar-dark">
            <div class="col-1">
              <a class="navbar-brand" href="/">
                <img src="../assets/images/logo.jpg" alt="Logo" style="width:40px;">
              </a>
            </div>
            <div class="col-9">
              <ul class="navbar-nav">
                <li class="nav-item">
                  <a class="nav-link" href="http://www.fb.com/NVM.Error">Facebook</a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="http://www.instagram.com/NVM.Error">Instagram</a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="">Gmail: Manhnv.dotnet@gmail.com</a>
                </li>
              </ul>
            </div>  
            <div class="col-2">
              <ul class="navbar-nav">
                <li class="nav-item">
                  <router-link class="nav-link" to="/login">Login</router-link>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="">|</a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="">Register</a>
                </li>
              </ul>
            </div>   
      </nav>
      </div>
    </div>
    <div class="home">
        <Sidebar/>
        <div class="content"><router-view/></div>    
    </div>        
    </div>
</template>

<script>
import Sidebar from '../components/Sidebar'
export default {
    name: 'home',
    components: {
        Sidebar
    }
}
</script>

<style>
.home {
    display: grid;
    grid-template-columns: 1fr 5fr;
    background-color: #3c8171;
    height: 100vh;
    width: 100vw;
}
.content {
    background-color: rgb(255, 255, 255);
    border-radius: 10px;
    margin: 6px 6px 6px 0px;
}
</style>