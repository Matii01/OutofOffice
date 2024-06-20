import transformObjectToQueryString from "../helper/transformToQueryString";
import { api } from "./api";

const leaveRequestApi = api.injectEndpoints({
  endpoints: (builder) => ({
    getLeaveRequests: builder.query({
      query: (params) => {
        const query = transformObjectToQueryString(params);
        return `LeaveRequest/leaverequests?${query}`;
      },
      transformResponse: (data) => {
        const transformed = data.map((it) => ({
          ...it,
          startDate: it.startDate.slice(0, 10),
          endDate: it.endDate.slice(0, 10),
        }));

        return transformed;
      },
    }),
    getForLeaveRequestDetails: builder.query({
      query: (leaveRequestId) => `LeaveRequest/${leaveRequestId}`,
      keepUnusedDataFor: 0,
      transformResponse: (data) => {
        const transformed = {
          ...data,
          endDate: data.endDate.slice(0, 10),
          startDate: data.startDate.slice(0, 10),
        };
        return transformed;
      },
    }),
    getForLeaveRequest: builder.query({
      query: () => {
        return `LeaveRequest/forleaverequest`;
      },
    }),
    createLeaveReques: builder.mutation({
      query: (request) => ({
        url: "LeaveRequest/createleaveRequest",
        method: "POST",
        body: JSON.stringify(request),
        headers: { "Content-Type": "application/json" },
      }),
    }),
    submitLeaveReques: builder.mutation({
      query: (id) => ({
        url: `LeaveRequest/submitleaveRequest/${id}`,
        method: "POST",
        headers: { "Content-Type": "application/json" },
      }),
    }),
    cancelLeaveReques: builder.mutation({
      query: (id) => ({
        url: `LeaveRequest/cancelleaveRequest/${id}`,
        method: "POST",
        headers: { "Content-Type": "application/json" },
      }),
    }),
  }),
});

export const {
  useGetLeaveRequestsQuery,
  useGetForLeaveRequestDetailsQuery,
  useGetForLeaveRequestQuery,
  useCreateLeaveRequesMutation,
  useSubmitLeaveRequesMutation,
  useCancelLeaveRequesMutation,
} = leaveRequestApi;
