import transformObjectToQueryString from "../helper/transformToQueryString";
import { api } from "./api";

const employeeApi = api.injectEndpoints({
  endpoints: (builder) => ({
    getEmployee: builder.query({
      query: (params) => {
        const query = transformObjectToQueryString(params);
        return `Employee/employee?${query}`;
      },
      keepUnusedDataFor: 0,
    }),
    getEmployeePosition: builder.query({
      query: () => {
        return `Employee/employeeposition`;
      },
    }),
    getNotInProjectEmployee: builder.query({
      query: (projectId) => {
        return `Employee/notinprojectemployee/${projectId}`;
      },
    }),
    getForNewEmployee: builder.query({
      query: () => {
        return `Employee/fornewemployee`;
      },
    }),
    addEmployee: builder.mutation({
      query: (employee) => ({
        url: "/Employee/addemployee",
        method: "POST",
        body: JSON.stringify(employee),
        headers: { "Content-Type": "application/json" },
      }),
    }),
    updateEmployee: builder.mutation({
      query: (updatedData) => ({
        url: "Employee/updateemployee",
        method: "POST",
        body: JSON.stringify(updatedData),
        headers: { "Content-Type": "application/json" },
      }),
    }),
  }),
});

export const {
  useGetEmployeeQuery,
  useGetForNewEmployeeQuery,
  useAddEmployeeMutation,
  useUpdateEmployeeMutation,
  useGetEmployeePositionQuery,
  useGetNotInProjectEmployeeQuery,
} = employeeApi;
