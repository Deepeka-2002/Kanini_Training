import {configureStore} from '@reduxjs/toolkit';
import listreducer from './listSlice';

const liststore = configureStore({
    reducer:{
        list: listreducer,
    }
})
export default liststore;