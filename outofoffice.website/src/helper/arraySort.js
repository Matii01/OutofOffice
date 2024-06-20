export function sortByFieldAsc(array, field) {
  return array.sort((a, b) => {
    if (a[field] < b[field]) {
      return -1;
    }
    if (a[field] > b[field]) {
      return 1;
    }
    return 0;
  });
}

export function sortByFieldDesc(array, fieldName) {
  return array.sort((a, b) => {
    if (a[fieldName] < b[fieldName]) {
      return 1;
    }
    if (a[fieldName] > b[fieldName]) {
      return -1;
    }
    return 0;
  });
}

export function filterBySearchParam(array, searchParam) {
  const lowerSearchParam = searchParam.toLowerCase();

  return array.filter((item) => {
    return Object.values(item).some((value) => {
      if (value != null) {
        return value.toString().toLowerCase().includes(lowerSearchParam);
      }
    });
  });
}
