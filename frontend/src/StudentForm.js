import React, { useState } from 'react';
import './App.css';

function StudentForm()
{
    const [formData, setFormData] = useState({
        StudentId: 0,
        StudentName: '',
        StudentSurname: '',
        StudentEmail: '',
        YearOfRegistration: 0,
        FileId: 0,
        SpecializationId: 0,
        ECTS: 0,
        HasUnfinishedExams: false,
        UnfinishedExams: '',
        SemesterId: 0
    });

    const handleChange = (e) =>
    {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value
        });
    };

    return (
        <form className='form'>
            <label>
                Student ID:
                <input
                    type="text"
                    name="StudentId"
                    value={formData.StudentId}
                    onChange={handleChange}
                />
            </label>
            <label>
                Student Name:
                <input
                    type="text"
                    name="StudentName"
                    value={formData.StudentName}
                    onChange={handleChange}
                />
            </label>
            <br />
            <label>
                Student Surname:
                <input
                    type="text"
                    name="StudentSurname"
                    value={formData.StudentSurname}
                    onChange={handleChange}
                />
            </label>
            <br />
            <label>
                Student Email:
                <input
                    type="email"
                    name="StudentEmail"
                    value={formData.StudentEmail}
                    onChange={handleChange}
                />
            </label>
            <br />
            <label>
                Year of Registration:
                <input
                    type="number"
                    name="YearOfRegistration"
                    value={formData.YearOfRegistration}
                    onChange={handleChange}
                />
            </label>
            <br />
            <label>
                Specialization ID:
                <input
                    type="number"
                    name="SpecializationId"
                    value={formData.SpecializationId}
                    onChange={handleChange}
                />
            </label>
            <br />
            <label>
                ECTS:
                <input
                    type="number"
                    name="ECTS"
                    value={formData.ECTS}
                    onChange={handleChange}
                />
            </label>
            <br />
            <label>
                Has Unfinished Exams:
                <select
                    name="HasUnfinishedExams"
                    value={formData.HasUnfinishedExams}
                    onChange={handleChange}
                >
                    <option value={false}>No</option>
                    <option value={true}>Yes</option>
                </select>
            </label>
            <br />
            {formData.HasUnfinishedExams && (
                <>
                    <label>
                        Unfinished Exams:
                        <select
                            name="UnfinishedExams"
                            value={formData.UnfinishedExams}
                            onChange={handleChange}
                        >
                            <option value="exam1">Exam 1</option>
                            <option value="exam2">Exam 2</option>
                            <option value="exam3">Exam 3</option>
                        </select>
                    </label>
                    <br />
                    <label>
                        Semester:
                        <input
                            type="number"
                            name="SemesterId"
                            value={formData.SemesterId}
                            onChange={handleChange}
                        />
                    </label>
                    <br />
                </>
            )}
            <button type="submit">Submit</button>
        </form>
    );
}

export default StudentForm;
