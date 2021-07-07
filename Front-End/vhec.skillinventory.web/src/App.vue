<template>
  <div id="app">
    <div class="row">
      <div class="col-12">
         <nav class="navbar navbar-expand-sm bg-dark navbar-dark">
            <div class="col-1">
              <a class="navbar-brand" href="/Dashboard">
                <img src="../src/assets/images/logo.jpg" alt="Logo" style="width:40px;">
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
              <!-- <form class="form-inline">
                <input class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search">
              <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button></form> -->
              <ul class="navbar-nav">
                <li class="nav-item">
                  <a class="nav-link" href="">Error</a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="">|</a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="">Logout</a>
                </li>
              </ul>
            </div>   
      </nav>
      </div>
    </div>
    <router-view></router-view>
  </div>
</template>

<script>
  export default {
    name: 'App'
  }
</script>

<style>
#app {
  font-family: 'Roboto', sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
body {
  margin: 0px;
  padding: 0px;
  box-sizing: border-box;
}
</style>