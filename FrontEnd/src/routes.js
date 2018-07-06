import Login from './views/Login.vue'
import NotFound from './views/404.vue'
import Home from './views/Home.vue'
import User from './views/User.vue'
import Department from './views/Department.vue'
import Role from './views/Role.vue'
import Permission from './views/Permission.vue'

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
        iconCls: 'el-icon-message',//图标样式class
        children: [
            // { path: '/main', component: Main, name: '主页', hidden: true },
            // { path: '/table', component: Table, name: 'Table' },
            // { path: '/form', component: Form, name: 'Form' },
            // { path: '/user', component: user, name: '列表' },
        ]
    },
    {
        path: '/user',
        component: User,
        name: '用户',
        iconCls: 'fa fa-id-card-o',
        // children: [
        //     // { path: '/page4', component: Page4, name: '页面4' },
        //     // { path: '/page5', component: Page5, name: '页面5' }
        // ]
    },
    {
        path: '/department',
        component: Department,
        name: '部门',
        iconCls: 'fa fa-address-card',
        leaf: true,//只有一个节点
        children: [
             //{ path: '/page6', component: Page6, name: '导航三' }
        ]
    },
    {
        path: '/role',
        component: Role,
        name: '角色',
        iconCls: 'fa fa-bar-chart',
        children: [
            // { path: '/echarts', component: echarts, name: 'echarts' }
        ]
    },
    {
        path: '/permission',
        component: Permission,
        name: '权限',
        iconCls: 'fa fa-bar-chart',
        children: [
            // { path: '/echarts', component: echarts, name: 'echarts' }
        ]
    },
    {
        path: '*',
        hidden: true,
        redirect: { path: '/404' }
    }
];

export default routes;