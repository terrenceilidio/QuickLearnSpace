import Vue from 'nativescript-vue';
import App from './components/App.vue';
import store from './store';
import FirebaseConfig from './servives/firebase.config'
import Navigator from 'nativescript-vue-navigator'
import Routers from './servives/router'
import VueDevtools from 'nativescript-vue-devtools';
import ButtonPlugin from 'nativescript-material-button/vue';
import TextFieldPlugin from 'nativescript-material-textfield/vue';
import RipplePlugin from 'nativescript-material-ripple/vue';

import {
  TNSFontIcon,
  fonticon
} from "nativescript-fonticon"; // require the couchbase module
import "./app.scss"

TNSFontIcon.debug = false;
TNSFontIcon.paths = {
  mdi: "./assets/materialdesignicons.css"
};
TNSFontIcon.loadCss();

(new FirebaseConfig()).init();

// Prints Vue logs when --env.production is *NOT* set while building
Vue.config.silent = (TNS_ENV === 'production');

Vue.registerElement(
  'RadSideDrawer',
  () => require('nativescript-ui-sidedrawer').RadSideDrawer
);
Vue.registerElement(
  'CardView',
  () => require('@nstudio/nativescript-cardview').CardView
);
Vue.registerElement(
  'Gif',
   () => require('nativescript-gif').Gif
);


if(TNS_ENV !== 'production') {
  Vue.use(VueDevtools);
}
Vue.use(Navigator,{
  routes: new Routers().getRoutes()
});
Vue.use(ButtonPlugin);
Vue.use(TextFieldPlugin);
Vue.use(RipplePlugin);

Vue.filter("fonticon", fonticon);

new Vue({
store,
  render: h => h('frame', [h(App)])
}).$start();
