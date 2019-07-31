import Vue from 'nativescript-vue';
import App from './components/App.vue';
import store from './store';
import FirebaseConfig from './servives/firebase.config'


import VueDevtools from 'nativescript-vue-devtools';

if(TNS_ENV !== 'production') {
  Vue.use(VueDevtools);
}

// Prints Vue logs when --env.production is *NOT* set while building
Vue.config.silent = (TNS_ENV === 'production');

Vue.registerElement(
  'RadSideDrawer',
  () => require('nativescript-ui-sidedrawer').RadSideDrawer
)
const  firebaseC=new FirebaseConfig();
firebaseC.init(); 
new Vue({
store,
  render: h => h('frame', [h(App)])
}).$start();
