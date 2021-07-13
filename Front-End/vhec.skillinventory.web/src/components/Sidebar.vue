<template>
    <div class="sidebar">
        <div class="title">
            <img src="../assets/images/logo.png" alt="" width="120px">
        </div>
        <div class="menu-items">
            <router-link to="/" active-class="active" tag="button" exact class="side-btn">
                <div class="link-container">
                    Overview
                </div>
            </router-link>
            <router-link to="/employee" active-class="active" tag="button" exact class="side-btn">
                <div class="link-container">
                    Employee
                </div>
            </router-link>
            <router-link to="/skill" active-class="active" tag="button" exact class="side-btn">
                <div class="link-container">
                    Skill
                </div>
            </router-link>
            <router-link to="/information" active-class="active" tag="button" exact class="side-btn">
                <div class="link-container">
                    Information
                </div>
            </router-link>
        </div>
    </div>
</template>

<script>
export default {
    
}
</script>

<style scoped>

.sidebar {
    height: 100%;
}
.title {
    color: white;
    font-size: 24px;
    margin-top: 10px;
}
.menu-items {
    display: flex;
    flex-direction: column;
    margin-top: 40px;
    margin-left: 6px;
}
.menu-items > * {
    margin-top: 60px;
}
.side-btn {
    border: none;
    padding: 16px 0px;
    cursor: pointer;
    font-size: 16px;
    font-weight: 500;
    color: white;
    background-color: transparent;
}
.side-btn:focus {
    outline: none;
}
.side-btn.active {
    position: relative;
    background-color: white;
    color: teal;
    font-weight: 600;
    margin-left: 10px;
    border-radius: 30px 0 0 30px;
}
</style>