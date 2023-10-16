import { createSlice } from "@reduxjs/toolkit";
import { apiSlice } from "../api/apiSlice";

const authSlice = createSlice({
  name: "auth",
  initialState: { token: null },
  reducers: {},
  extraReducers: (builder) => {
    builder.addMatcher(
      apiSlice.endpoints.login.matchFulfilled,
      (state, action) => {
        state.token = action.payload.accessToken;
      }
    );
  },
});

export default authSlice.reducer;

export const selectToken = (state) => state.auth.token;
