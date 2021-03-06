import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home'

Vue.use(VueRouter)

const routes = [{
    path: '',
    component: Home,
    children: [{
            path: 'login',
            component: () =>
                import ('../views/Login.vue')
        },
        {
            path: '',
            component: () =>
                import ('../views/Overview.vue')
        },
        {
            path: 'employee',
            component: () =>
                import ('../views/Employee.vue')
        },
        {
            path: 'skill',
            component: () =>
                import ('../views/Skill.vue')
        },
        {
            path: 'information',
            component: () =>
                import ('../views/Information.vue')
        }
    ]
}]

const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
})

export default router