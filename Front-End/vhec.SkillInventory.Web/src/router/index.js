import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home'

Vue.use(VueRouter)

const routes = [
  {
    path: '',
    component: Home,
    children: [
      {
        path: '',
        component: () => import(/* webpackChunkName: "Overview" */ '../views/Home.vue')
      },
      {
        path: 'employee',
        component: () => import(/* webpackChunkName: "Messages" */ '../views/Employee.vue')
      },
      {
        path: 'skill',
        component: () => import(/* webpackChunkName: "Profile" */ '../views/Skill.vue')
      },
      {
        path: 'information',
        component: () => import(/* webpackChunkName: "Settings" */ '../views/Information.vue')
      }
    ]
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router