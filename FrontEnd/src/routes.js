import Login from './views/Login.vue'
import NotFound from './views/404.vue'
import Home from './views/Home.vue'
import User from './views/User.vue'
import Department from './views/Department.vue'
import Role from './views/Role.vue'
import Permission from './views/Permission.vue'
import Statistics from './views/Statistics.vue'

let routes = [
    {
        path: '/login',
        component: Login,
        name: '',
        hidden: true
    },
    {
        path: '/404',
        component: NotFound,
        name: '',
        hidden: true
    },
    {
        path: '/',
        component: Home,
        name: '首页',
        iconCls: 'el-icon-message',
        leaf: true,
        children: [
            { path: '/statistics', component: Statistics, name: '首页' },
        ]
    },
    {
        path: '/',
        component: Home,
        name: '用户',
        iconCls: 'fa fa-id-card-o',
        leaf: true,
        children: [
            { path: '/user', component: User, name: '用户' },
        ]
    },
    {
        path: '/',
        component: Home,
        name: '部门',
        iconCls: 'fa fa-address-card',
        leaf: true,//只有一个节点
        children: [
             { path: '/department', component: Department, name: '部门' }
        ]
    },
    {
        path: '/',
        component: Home,
        name: '角色',
        iconCls: 'fa fa-bar-chart',
        leaf: true,
        children: [
            { path: '/role', component: Role, name: '角色' }
        ]
    },
    {
        path: '/',
        component: Home,
        name: '权限',
        iconCls: 'fa fa-bar-chart',
        leaf: true,
        children: [
            { path: '/permission', component: Permission, name: '权限' }
        ]
    },
    {
        path: '*',
        hidden: true,
        redirect: { path: '/404' }
    }
];

export default routes;