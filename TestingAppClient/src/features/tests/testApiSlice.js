import { apiSlice } from "../api/apiSlice";
import { createEntityAdapter } from "@reduxjs/toolkit";

const testAdapter = createEntityAdapter();
const initialState = testAdapter.getInitialState();

export const testApiSlice = apiSlice.injectEndpoints({
  endpoints: (builder) => ({
    getUserTests: builder.query({
      query: (accessToken) => ({
        url: "/Test/GetTests",
        headers: { Authorization: `Bearer ${accessToken}` },
      }),
      transformResponse: (responseData) => {
        return testAdapter.setAll(initialState, responseData);
      },
      providesTags: (result, error, arg) => [
        { type: "Test", id: "LIST" },
        ...result.ids.map((id) => ({ type: "Test", id })),
      ],
    }),
  }),
});

export const { useGetUserTestsQuery } = testApiSlice;
