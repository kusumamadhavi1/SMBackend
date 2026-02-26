using AutoMapper;
using StudentPR.DTOs.Requests;

namespace StudentPR.Mappings
{
    public class StudentProfile: Profile
    {
        public StudentProfile() {
            // Entity → Response DTO
            CreateMap<StudentPR.Models.Student, StudentResponseDto>();

            // Request DTO → Entity
            CreateMap<StudentRequestDto, StudentPR.Models.Student>();
        }
    }
}
