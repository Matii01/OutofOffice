import transformObjectToQueryString from "../helper/transformToQueryString";
import { api } from "./api";

const approvalRequestApi = api.injectEndpoints({
  endpoints: (builder) => ({
    getApprovalRequests: builder.query({
      query: (params) => {
        const query = transformObjectToQueryString(params);
        return `ApprovalRequest/approvalrequest?${query}`;
      },
      keepUnusedDataFor: 0,
    }),
    getApprovalRequestsDetails: builder.query({
      query: (approvalRequestId) => {
        return `ApprovalRequest/approvalrequest/${approvalRequestId}`;
      },
      transformResponse: (data) => {
        const transformed = {
          ...data,
          comment: data.comment ?? "",
          leaveRequest: {
            ...data.leaveRequest,
            endDate: data.leaveRequest.endDate.slice(0, 10),
            startDate: data.leaveRequest.startDate.slice(0, 10),
          },
        };
        return transformed;
      },
    }),
    getForApprovalRequest: builder.query({
      query: () => `ApprovalRequest/forapprovalrequest`,
    }),
    acceptApprovalReques: builder.mutation({
      query: (data) => ({
        url: `ApprovalRequest/accept/${data.id}`,
        method: "POST",
        body: JSON.stringify(data.comment),
        headers: { "Content-Type": "application/json" },
      }),
    }),
    rejectApprovalReques: builder.mutation({
      query: (data) => ({
        url: `ApprovalRequest/reject/${data.id}`,
        method: "POST",
        body: JSON.stringify(data.comment),
        headers: { "Content-Type": "application/json" },
      }),
    }),
  }),
});

export const {
  useGetApprovalRequestsQuery,
  useGetApprovalRequestsDetailsQuery,
  useGetForApprovalRequestQuery,
  useAcceptApprovalRequesMutation,
  useRejectApprovalRequesMutation,
} = approvalRequestApi;
