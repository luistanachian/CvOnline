USE [Abilities]
GO

SELECT g.skillGroup, c.company, s.skill, sv.version, sv.releaseDate
  FROM SkillVersions as sv
  inner join Skills as s on s.idSkill = sv.idSkill
  inner join Companies as c on c.idCompany = s.idCompany
  inner join SkillGroups as g on g.idSkillGroup = s.idSkillGroup
  order by sv.releaseDate