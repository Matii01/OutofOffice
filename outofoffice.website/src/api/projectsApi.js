import transformObjectToQueryString from "../helper/transformToQueryString";
import { api } from "./api";

const employeeApi = api.injectEndpoints({
  endpoints: (builder) => ({
    getProjects: builder.query({
      query: (params) => {
        const query = transformObjectToQueryString(params);
        return `Project/projects?${query}`;
      },
      keepUnusedDataFor: 0,
    }),
    getProjectsDetails: builder.query({
      query: (id) => `Project/projectDetails/${id}`,
      keepUnusedDataFor: 0,
      transformResponse: (data) => {
        const transformed = {
          id: data.project.id,
          projectType: data.project.projectType,
          startDate: data.project.startDate.slice(0, 10),
          endDate:
            data.project.endDate == null
              ? ""
              : data.project.endDate.slice(0, 10),
          projectManager: data.project.projectManager,
          status: data.project.status,
          comment: data.project.comment,
        };

        return { employee: data.employee, project: transformed };
      },
    }),
    getForNewProject: builder.query({
      query: () => {
        return `Project/fornewproject`;
      },
    }),
    addProject: builder.mutation({
      query: (project) => ({
        url: "Project/addproject",
        method: "POST",
        body: JSON.stringify(project),
        headers: { "Content-Type": "application/json" },
      }),
    }),
    updateProject: builder.mutation({
      query: (project) => ({
        url: `Project/updateproject/${project.ID}`,
        method: "POST",
        body: JSON.stringify({
          projectType: project.projectType,
          startDate: project.startDate,
          endDate: project.endDate === "" ? null : project.endDate,
          projectManager: project.projectManager,
          comment: project.comment,
          status: project.status,
        }),
        headers: { "Content-Type": "application/json" },
      }),
    }),
    assignEmployeetoProject: builder.mutation({
      query: (employeProject) => ({
        url: "Project/assignemploye",
        method: "POST",
        body: JSON.stringify(employeProject),
        headers: { "Content-Type": "application/json" },
      }),
    }),
    removeEmployeeFromProject: builder.mutation({
      query: (data) => ({
        url: `Project/deletefromproject/${data.projectId}/${data.employeeId}`,
        method: "DELETE",
        headers: { "Content-Type": "application/json" },
      }),
    }),
  }),
});

export const {
  useAddProjectMutation,
  useGetForNewProjectQuery,
  useGetProjectsQuery,
  useGetProjectsDetailsQuery,
  useUpdateProjectMutation,
  useAssignEmployeetoProjectMutation,
  useRemoveEmployeeFromProjectMutation,
} = employeeApi;
