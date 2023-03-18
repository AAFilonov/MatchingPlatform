import * as Vue from 'vue'
import './style.css'
import App from './App.vue'
import '@mdi/font/css/materialdesignicons.css' // Ensure you are using css-loader
// Vuetify
import 'vuetify/styles'
import {createVuetify} from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import {aliases, mdi} from 'vuetify/iconsets/mdi'

const vuetify = createVuetify({
    theme: {
        defaultTheme: 'dark'
    },
    icons: {
        defaultSet: 'mdi',
        aliases,
        sets: {
            mdi,
        }
    },
    components,
    directives,
})

Vue.createApp(App)
    .use(vuetify)
    .mount('#app')
