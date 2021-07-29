  
export const getCurrentUser = () => {
  return JSON.parse(sessionStorage.getItem("token"));
};

export function authHeader() {
  const user = JSON.parse(sessionStorage.getItem("token"));
  if (user && user.userId) {
    return { token: user.userId };
  } else {
    return {};
  }

}