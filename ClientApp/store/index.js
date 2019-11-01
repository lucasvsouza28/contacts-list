import Vue from 'vue'
import Vuex from 'vuex'
import mutations from './mutations';
import actions from './actions';
import getters from './getters';

Vue.use(Vuex)

// STATE
const state = {
  contacts: [],
  loadingContacts: false,
  message: '',
  selectedId: null,
  loadingInfos: false,
  filter: ''
}

export default new Vuex.Store({
  state,
  mutations,
  actions,
  getters
})
