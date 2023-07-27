import{createSlice} from'@reduxjs/toolkit';

const listSlice = createSlice({
    name:'list',
    initialState:[],
    reducers: {
        addList:(state,action) => {
            state.push(action.payload);
        },
        removeList:(state,action) => {
            return state.filter((list )=> list.id!== action.payload);
        },
    },

});

export default listSlice.reducer;
export const {addList, removeList} = listSlice.actions;