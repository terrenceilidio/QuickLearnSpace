import Login from '../components/Login.vue'


export default class Router{
    getRoutes(){
    return {
        "/login":{
            component:Login,
        }
    }
 }
}