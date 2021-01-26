
import * as actions from './actions';
import * as mutations from './mutations';
import * as getters from './getters'
import state from './defaultState';

export default {
    namespaced: true,
    state,
    actions,
    mutations,
    getters
};

