<template>
  <div id="app">
    <nav class="navbar navbar-expand-sm bg-dark navbar-dark">
   <a class="navbar-brand" href="/Dashboard">
    <img src="../src/assets/images/logo.jpg" alt="Logo" style="width:40px;">
  </a>
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
</nav>
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